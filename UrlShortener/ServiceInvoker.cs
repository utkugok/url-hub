using UrlShortener.Interfaces;

namespace UrlShortener;

public class ServiceInvoker : IServiceInvoker
{
    public ServiceInvoker()
    {
    }

    public TResp Invoke<TResp>(Func<TResp> func)
    {
        try
        {
            return func();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}