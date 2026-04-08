namespace Auth0.MyOrganizationApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ForbiddenError(ErrorResponseContent body)
    : MyOrganizationApiException("ForbiddenError", 403, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorResponseContent Body => body;
}
