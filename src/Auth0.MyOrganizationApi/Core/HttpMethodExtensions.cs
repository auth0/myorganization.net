using global::System.Net.Http;

namespace Auth0.MyOrganizationApi.Core;

internal static class HttpMethodExtensions
{
    public static readonly HttpMethod Patch = new("PATCH");
}
