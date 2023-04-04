namespace UrlShortener.Biz.AppService.ShortedUrlsService;

public class ShortedUrl
{
    public long? UrlId { get; set; }
    public string Url { get; set; }
    public string NewUrl { get; set; }
}
