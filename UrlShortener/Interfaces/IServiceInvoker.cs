namespace UrlShortener.Interfaces;

public interface IServiceInvoker
{
    TResp Invoke<TResp>(Func<TResp> func);
}
