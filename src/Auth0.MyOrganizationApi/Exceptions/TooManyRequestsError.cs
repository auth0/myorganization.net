namespace Auth0.MyOrganizationApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class TooManyRequestsError(ErrorResponseContent body)
    : MyOrganizationApiException("TooManyRequestsError", 429, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorResponseContent Body => body;
}
