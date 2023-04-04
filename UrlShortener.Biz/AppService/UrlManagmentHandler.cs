using UrlShortener.Biz.AppService.RedirectUrlService;
using UrlShortener.Biz.AppService.ShortedUrlsService;
using UrlShortener.Biz.Extensions;
using UrlShortener.Biz.Model;

namespace UrlShortener.Biz.AppService.ShortUrlService;

public interface IUrlManagmentHandler
{
    ShortUrlResultDTO ShortUrl(ShortUrlDTO shortUrl);

    ShortedUrlsResultDTO ShortedUrls();

    RedirectUrlResultDTO RedirectUrl(RedirectUrlDTO redirectUrl);
}

public class ShortUrlHandler : IUrlManagmentHandler
{
    private readonly IUrlRequestBuilder urlRequestBuilder;
    private readonly IUrlValidator urlValidator;

    public ShortUrlHandler(IUrlValidator _urlValidator, IUrlRequestBuilder _urlRequestBuilder)
    {
        urlValidator = _urlValidator;
        urlRequestBuilder = _urlRequestBuilder;
    }

    public RedirectUrlResultDTO RedirectUrl(RedirectUrlDTO redirectUrl)
    {
        string url = urlRequestBuilder.GetUrl(redirectUrl.url);

        if (!string.IsNullOrEmpty(url))
        {
            return new RedirectUrlResultDTO()
            {
                Code = "0000",
                IsSuccess = true,
                Message = "success redirect url",
                RedirectUrl = url
            };
        }

        return new RedirectUrlResultDTO()
        {
            Code = "9999",
            IsSuccess = false,
            Message = $"url: '{redirectUrl.url}' does not exist"
        };
    }

    public ShortedUrlsResultDTO ShortedUrls()
    {
        List<ShortedUrl> urls = urlRequestBuilder.GetUrls();

        return new ShortedUrlsResultDTO()
        {
            Code = "0000",
            IsSuccess = true,
            Message = "success shorted urls",
            ShortedUrlsResult = urls
        };
    }

    public ShortUrlResultDTO ShortUrl(ShortUrlDTO shortUrl)
    {
        var validationResult = urlValidator.Validate(shortUrl);

        if (validationResult is not null && validationResult.Any())
        {
            var response = validationResult.ToUrlValidationException();

            return new ShortUrlResultDTO()
            {
                IsSuccess = false,
                Code = response.Code,
                Message = response.Message
            };
        }

        ShortUrl url = urlRequestBuilder.Create(shortUrl);

        return new ShortUrlResultDTO()
        {
            Code = "0000",
            IsSuccess = true,
            Message = "success shorted url",
            UrlId = url.Id,
            ShortedUrl = url.Origin + url.Path
        };
    }
}