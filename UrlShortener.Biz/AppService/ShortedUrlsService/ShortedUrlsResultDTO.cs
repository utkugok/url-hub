using UrlShortener.Biz.Model;

namespace UrlShortener.Biz.AppService.ShortedUrlsService;

public class ShortedUrlsResultDTO : BaseResultDTO
{
    public List<ShortedUrl>? ShortedUrlsResult { get; set; }
}
