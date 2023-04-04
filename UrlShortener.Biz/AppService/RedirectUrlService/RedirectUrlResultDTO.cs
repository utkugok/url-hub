using UrlShortener.Biz.Model;

namespace UrlShortener.Biz.AppService.RedirectUrlService;

public class RedirectUrlResultDTO : BaseResultDTO
{
    public string? RedirectUrl { get; set; }
}
