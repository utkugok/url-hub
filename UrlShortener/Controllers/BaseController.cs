using Microsoft.AspNetCore.Mvc;
using UrlShortener.Model;

namespace UrlShortener.Controllers;

[Consumes("application/json", new string[] { })]
[Produces("application/json", new string[] { })]
[ApiController]
public class BaseController : ControllerBase
{
    private readonly ILogger<BaseController> logger;

    protected BaseController(ILogger<BaseController> _logger)
    {
        logger = _logger;
    }

    protected BaseResponse<T> GenerateReturnModel<T>(T obj)
    {
        BaseResponse<T> baseResponse = new BaseResponse<T>
        {
            Data = obj
        };

        logger.LogInformation($"Response: {baseResponse} ");

        return baseResponse;
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Ok<T>(T response)
    {
        return base.Ok(GenerateReturnModel(response));
    }
}
