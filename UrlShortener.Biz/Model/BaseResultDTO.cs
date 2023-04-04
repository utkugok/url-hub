namespace UrlShortener.Biz.Model;

public class BaseResultDTO
{
    public bool IsSuccess { get; set; }

    public string Code { get; set; }

    public string Message { get; set; }
}
