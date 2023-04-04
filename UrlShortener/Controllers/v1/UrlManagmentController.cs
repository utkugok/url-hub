using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UrlShortener.Biz.AppService.ShortUrlService;
using UrlShortener.Interfaces;
using UrlShortener.Model;

namespace UrlShortener.Controllers.v1;

[Route("/api/v1/[controller]/")]
[ApiController]
public class UrlManagmentController : BaseController, IUrlManagment
{
    private readonly ILogger<UrlManagmentController> logger;
    private readonly IServiceInvoker serviceInvoker;
    private readonly IUrlManagmentHandler urlManagmentHandler;

    public UrlManagmentController(ILogger<UrlManagmentController> _logger, IServiceInvoker _serviceInvoker, IUrlManagmentHandler _urlManagmentHandler) : base(_logger)
    {
        logger = _logger;
        serviceInvoker = _serviceInvoker;
        urlManagmentHandler = _urlManagmentHandler;
    }

    [HttpPost]
    [Route("shorturl")]
    [SwaggerOperation(
        Summary = "Short Url",
        Description = "Short Url",
        OperationId = "shorturl"
    )]
    public ShortUrlResponse ShortUrl(ShortUrlRequest shortUrlRequest)
    {
        return serviceInvoker.Invoke(() => new ShortUrlResponse
        {
            ShortUrlResult = urlManagmentHandler.ShortUrl(shortUrlRequest.UrlRequest)
        });
    }

    [HttpGet]
    [Route("shortedurls")]
    [SwaggerOperation(
        Summary = "Shorted Urls",
        Description = "Shorted Urls",
        OperationId = "shortedurls"
    )]
    public ShortedUrlsResponse ShortedUrls()
    {
        return serviceInvoker.Invoke(() => new ShortedUrlsResponse
        {
            ShortedUrlsResult = urlManagmentHandler.ShortedUrls()
        });
    }

    [HttpPost]
    [Route("redirecturl")]
    [SwaggerOperation(
        Summary = "Redirect Url",
        Description = "Redirect Url",
        OperationId = "redirecturl"
    )]
    public RedirectUrlResponse RedirectUrl(RedirectUrlRequest redirectUrlRequest)
    {
        return serviceInvoker.Invoke(() => new RedirectUrlResponse
        {
            RedirectUrlResult = urlManagmentHandler.RedirectUrl(redirectUrlRequest.UrlRequest)
        });
    }
}
