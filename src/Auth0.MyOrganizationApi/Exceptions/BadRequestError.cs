namespace Auth0.MyOrganizationApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(object body, Auth0.MyOrganizationApi.RawResponse? rawResponse = null)
    : MyOrganizationApiException("BadRequestError", 400, body, rawResponse: rawResponse);
