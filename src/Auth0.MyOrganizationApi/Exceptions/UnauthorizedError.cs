namespace Auth0.MyOrganizationApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnauthorizedError(
    ErrorResponseContent body,
    Auth0.MyOrganizationApi.RawResponse? rawResponse = null
) : MyOrganizationApiException("UnauthorizedError", 401, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorResponseContent Body => body;
}
