using Auth0.MyOrganizationApi.Core;
using Auth0.MyOrganizationApi.Organization;

namespace Auth0.MyOrganizationApi;

public partial class MyOrganizationApiClient : IMyOrganizationApiClient
{
    private readonly RawClient _client;

    public MyOrganizationApiClient(string? token = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(new Dictionary<string, string>() { });
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "Authorization", $"Bearer {token ?? ""}" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        OrganizationDetails = new OrganizationDetailsClient(_client);
        Organization = new OrganizationClient(_client);
    }

    public IOrganizationDetailsClient OrganizationDetails { get; }

    public IOrganizationClient Organization { get; }
}
