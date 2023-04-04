using UrlShortener.Biz.AppService.ShortUrlService;
using UrlShortener.Biz.Data;
using UrlShortener.Biz.Model.Validation;

namespace UrlShortener.Biz.AppService;

public interface IUrlValidator
{
    UrlValidationResultList Validate(ShortUrlDTO queryRequest);
}

public class UrlValidator : IUrlValidator
{
    public UrlValidationResultList Validate(ShortUrlDTO queryRequest)
    {
        var result = new UrlValidationResultList();

        if (queryRequest.url is null)
        {
            result.Add(new ValidationResult()
            {
                ErrorCode = "5000",
                Description = "url can not be null"
            });
        }
        else if (queryRequest.url is "")
        {
            result.Add(new ValidationResult()
            {
                ErrorCode = "5001",
                Description = "url can not be empty"
            });
        }
        else
        {
            if (queryRequest.url.Contains(","))
            {
                result.Add(new ValidationResult()
                {
                    ErrorCode = "5002",
                    Description = "url can not contain commas ( , )"
                });
            }
        }

        Uri uriResult;
        if (!Uri.TryCreate(queryRequest.url, UriKind.Absolute, out uriResult))
        {
            result.Add(new ValidationResult()
            {
                ErrorCode = "5003",
                Description = $"url: '{queryRequest.url}' is not valid"
            });
        }
        if (UrlData.ShortUrlDTOList.Any(q => q.InputUrl == queryRequest.url))
        {
            result.Add(new ValidationResult()
            {
                ErrorCode = "5004",
                Description = $"url: '{queryRequest.url}' already exist."
            });
        }

        return result;
    }
}
