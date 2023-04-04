using UrlShortener.Biz.Model.Validation;
using UrlShortener.Model;

namespace UrlShortener.Biz.Extensions;

public static class UrlValidationResultExtensions
{
    public static MessageResponse ToUrlValidationException(this UrlValidationResultList urlValidationResults)
    {
        var firstValidationError = urlValidationResults.First();

        return new MessageResponse(firstValidationError.ErrorCode, firstValidationError.Description);
    }
}
