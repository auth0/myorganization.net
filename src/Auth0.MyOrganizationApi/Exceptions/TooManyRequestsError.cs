namespace Auth0.MyOrganizationApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class TooManyRequestsError(
    ErrorResponseContent body,
    Auth0.MyOrganizationApi.RawResponse? rawResponse = null
) : MyOrganizationApiException("TooManyRequestsError", 429, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorResponseContent Body => body;
}
