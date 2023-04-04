using UrlShortener.Biz.Model;

namespace UrlShortener.Biz.AppService.ShortUrlService;

public class ShortUrlResultDTO : BaseResultDTO
{
    public long? UrlId { get; set; }
    public string ShortedUrl { get; set; }
}
