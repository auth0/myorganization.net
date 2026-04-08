namespace Auth0.MyOrganizationApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ConflictError(ErrorResponseContent body)
    : MyOrganizationApiException("ConflictError", 409, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorResponseContent Body => body;
}
