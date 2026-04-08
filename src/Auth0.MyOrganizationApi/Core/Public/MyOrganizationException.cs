namespace Auth0.MyOrganizationApi;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class MyOrganizationException(string message, Exception? innerException = null)
    : Exception(message, innerException);
