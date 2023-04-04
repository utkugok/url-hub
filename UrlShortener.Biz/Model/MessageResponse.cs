namespace UrlShortener.Model;

public class MessageResponse
{
    public MessageResponse(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; set; }

    public string Message { get; set; }
}
