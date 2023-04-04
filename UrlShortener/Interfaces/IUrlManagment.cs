using UrlShortener.Model;

namespace UrlShortener.Interfaces
{
    public interface IUrlManagment
    {
        ShortUrlResponse ShortUrl(ShortUrlRequest request);

        ShortedUrlsResponse ShortedUrls();

        RedirectUrlResponse RedirectUrl(RedirectUrlRequest request);
    }
}