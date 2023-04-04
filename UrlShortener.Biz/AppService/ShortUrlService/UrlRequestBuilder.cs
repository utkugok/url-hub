using UrlShortener.Biz.AppService.ShortedUrlsService;
using UrlShortener.Biz.Data;
using UrlShortener.Biz.Model;

namespace UrlShortener.Biz.AppService.ShortUrlService;

public interface IUrlRequestBuilder
{
    ShortUrl Create(ShortUrlDTO request);

    string GetUrl(string url);

    List<ShortedUrl> GetUrls();
}

public class UrlRequestBuilder : IUrlRequestBuilder
{
    public ShortUrl Create(ShortUrlDTO request)
    {
        return UrlData.AddList(request);
    }

    public List<ShortedUrl> GetUrls()
    {
        return UrlData.GetUrls();
    }

    public string GetUrl(string url)
    {
        return UrlData.GetUrl(url);
    }
}
