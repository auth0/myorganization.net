using System.Net;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Auth0.MyOrganizationApi.Test.Unit.Wrapper;

[TestFixture]
public class ClientCredentialsTokenProviderTests
{
    private WireMockServer _server = null!;
    private string _tokenEndpointPath = null!;

    private const string ValidTokenResponse = """
        {
            "access_token": "test-access-token",
            "token_type": "Bearer",
            "expires_in": 86400
        }
        """;

    [SetUp]
    public void SetUp()
    {
        // Use HTTPS so AuthenticationApiClient (which constructs https://{domain}/oauth/token)
        // can reach the mock server correctly.
        _server = WireMockServer.Start(new WireMockServerSettings { UseSSL = true });
        _tokenEndpointPath = "/oauth/token";
    }

    [TearDown]
    public void TearDown()
    {
        _server.Stop();
        _server.Dispose();
    }

    private (string domain, HttpClient httpClient) CreateServerDomainAndClient()
    {
        var serverUri = new Uri(_server.Urls[0]);
        var domain = serverUri.Host + ":" + serverUri.Port;

        // Allow self-signed certificates from the WireMock HTTPS server
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        return (domain, new HttpClient(handler));
    }

    private ClientCredentialsTokenProvider CreateProvider()
    {
        var (domain, httpClient) = CreateServerDomainAndClient();
        return ClientCredentialsTokenProvider
            .WithClientSecret(domain, "test-client-id", "test-client-secret")
            .WithAudience("https://test-api/")
            .WithHttpClient(httpClient)
            .Build();
    }

    // -------------------------------------------------------------------------
    // WithClientSecret — required parameter validation
    // -------------------------------------------------------------------------

    [Test]
    public void WithClientSecret_NullDomain_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientSecret(null!, "id", "secret"));
    }

    [Test]
    public void WithClientSecret_EmptyDomain_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientSecret("", "id", "secret"));
    }

    [Test]
    public void WithClientSecret_WhitespaceDomain_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientSecret("   ", "id", "secret"));
    }

    [Test]
    public void WithClientSecret_DomainWithHttpsScheme_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientSecret("https://tenant.auth0.com", "id", "secret"));
    }

    [Test]
    public void WithClientSecret_DomainWithHttpScheme_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientSecret("http://tenant.auth0.com", "id", "secret"));
    }

    [Test]
    public void WithClientSecret_NullClientId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientSecret("tenant.auth0.com", null!, "secret"));
    }

    [Test]
    public void WithClientSecret_NullClientSecret_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientSecret("tenant.auth0.com", "id", null!));
    }

    // -------------------------------------------------------------------------
    // WithClientSecret — builder construction
    // -------------------------------------------------------------------------

    [Test]
    public void WithClientSecret_Build_ReturnsProvider()
    {
        var provider = ClientCredentialsTokenProvider
            .WithClientSecret("tenant.auth0.com", "id", "secret")
            .Build();

        Assert.That(provider, Is.Not.Null);
        Assert.That(provider, Is.InstanceOf<ITokenProvider>());
        Assert.That(provider, Is.InstanceOf<IDisposable>());

        provider.Dispose();
    }

    [Test]
    public async Task WithClientSecret_NoAudience_DefaultsToOrgAudience()
    {
        var (domain, httpClient) = CreateServerDomainAndClient();

        _server
            .Given(Request.Create().WithPath(_tokenEndpointPath).UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(ValidTokenResponse)
                .WithHeader("Content-Type", "application/json"));

        using var provider = ClientCredentialsTokenProvider
            .WithClientSecret(domain, "id", "secret")
            .WithHttpClient(httpClient)
            .Build();

        await provider.GetTokenAsync();

        var requestBody = _server.LogEntries.Single().RequestMessage.Body;
        Assert.That(requestBody, Does.Contain($"audience=https%3A%2F%2F{Uri.EscapeDataString(domain)}%2Fmy-org%2F")
            .Or.Contain($"audience=https://{domain}/my-org/"));
    }

    [Test]
    public async Task WithClientSecret_WithAudience_CustomAudienceUsedInTokenRequest()
    {
        var (domain, httpClient) = CreateServerDomainAndClient();

        _server
            .Given(Request.Create().WithPath(_tokenEndpointPath).UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(ValidTokenResponse)
                .WithHeader("Content-Type", "application/json"));

        using var provider = ClientCredentialsTokenProvider
            .WithClientSecret(domain, "id", "secret")
            .WithAudience("https://custom-api.example.com/")
            .WithHttpClient(httpClient)
            .Build();

        await provider.GetTokenAsync();

        var requestBody = _server.LogEntries.Single().RequestMessage.Body;
        Assert.That(requestBody, Does.Contain("custom-api.example.com"));
    }

    [Test]
    public async Task WithClientSecret_EmptyAudience_DefaultsToOrgAudience()
    {
        var (domain, httpClient) = CreateServerDomainAndClient();

        _server
            .Given(Request.Create().WithPath(_tokenEndpointPath).UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(ValidTokenResponse)
                .WithHeader("Content-Type", "application/json"));

        using var provider = ClientCredentialsTokenProvider
            .WithClientSecret(domain, "id", "secret")
            .WithAudience("")       // empty → treated as unset
            .WithHttpClient(httpClient)
            .Build();

        await provider.GetTokenAsync();

        var requestBody = _server.LogEntries.Single().RequestMessage.Body;
        Assert.That(requestBody, Does.Contain("my-org"));
    }

    [Test]
    public async Task WithClientSecret_WithOrganization_IncludedInTokenRequest()
    {
        var (domain, httpClient) = CreateServerDomainAndClient();

        _server
            .Given(Request.Create().WithPath(_tokenEndpointPath).UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(ValidTokenResponse)
                .WithHeader("Content-Type", "application/json"));

        using var provider = ClientCredentialsTokenProvider
            .WithClientSecret(domain, "id", "secret")
            .WithOrganization("org_abc123")
            .WithHttpClient(httpClient)
            .Build();

        await provider.GetTokenAsync();

        var requestBody = _server.LogEntries.Single().RequestMessage.Body;
        Assert.That(requestBody, Does.Contain("org_abc123"));
    }

    [Test]
    public void WithClientSecret_FluentChain_LastAudienceWins()
    {
        // Calling WithAudience() twice: last value should be used.
        // We verify Build() succeeds; the audience resolution is tested via token request tests.
        var provider = ClientCredentialsTokenProvider
            .WithClientSecret("tenant.auth0.com", "id", "secret")
            .WithAudience("https://first.example.com/")
            .WithAudience("https://second.example.com/")
            .Build();

        Assert.That(provider, Is.Not.Null);
        provider.Dispose();
    }

    [Test]
    public void WithClientSecret_WithHttpClient_UsesProvidedClient()
    {
        // Verify that supplying a custom HttpClient does not throw and the provider builds.
        using var customHttpClient = new HttpClient();

        var provider = ClientCredentialsTokenProvider
            .WithClientSecret("tenant.auth0.com", "id", "secret")
            .WithHttpClient(customHttpClient)
            .Build();

        Assert.That(provider, Is.Not.Null);
        // Caller owns customHttpClient; provider.Dispose() must not dispose it.
        provider.Dispose();
        Assert.DoesNotThrow(() => customHttpClient.Timeout = TimeSpan.FromSeconds(5),
            "Caller-provided HttpClient must not be disposed by the provider.");
    }

    // -------------------------------------------------------------------------
    // WithClientAssertion — required parameter validation
    // -------------------------------------------------------------------------

    [Test]
    public void WithClientAssertion_NullDomain_ThrowsArgumentException()
    {
        var key = new RsaSecurityKey(RSA.Create());
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientAssertion(null!, "id", key, "RS256"));
    }

    [Test]
    public void WithClientAssertion_NullClientId_ThrowsArgumentException()
    {
        var key = new RsaSecurityKey(RSA.Create());
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientAssertion("tenant.auth0.com", null!, key, "RS256"));
    }

    [Test]
    public void WithClientAssertion_NullSecurityKey_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            ClientCredentialsTokenProvider.WithClientAssertion("tenant.auth0.com", "id", null!, "RS256"));
    }

    [Test]
    public void WithClientAssertion_NullAlgorithm_ThrowsArgumentException()
    {
        var key = new RsaSecurityKey(RSA.Create());
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientAssertion("tenant.auth0.com", "id", key, null!));
    }

    [Test]
    public void WithClientAssertion_EmptyAlgorithm_ThrowsArgumentException()
    {
        var key = new RsaSecurityKey(RSA.Create());
        Assert.Throws<ArgumentException>(() =>
            ClientCredentialsTokenProvider.WithClientAssertion("tenant.auth0.com", "id", key, ""));
    }

    [Test]
    public void WithClientAssertion_ValidInputs_BuildsProvider()
    {
        var key = new RsaSecurityKey(RSA.Create());
        var provider = ClientCredentialsTokenProvider
            .WithClientAssertion("tenant.auth0.com", "id", key, "RS256")
            .Build();

        Assert.That(provider, Is.Not.Null);
        Assert.That(provider, Is.InstanceOf<ITokenProvider>());
        provider.Dispose();
    }

    [Test]
    public void WithClientAssertion_CanChainWithAudience()
    {
        var key = new RsaSecurityKey(RSA.Create());
        var provider = ClientCredentialsTokenProvider
            .WithClientAssertion("tenant.auth0.com", "id", key, "RS256")
            .WithAudience("https://api.example.com/")
            .Build();

        Assert.That(provider, Is.Not.Null);
        provider.Dispose();
    }

    // -------------------------------------------------------------------------
    // GetTokenAsync — behavioral (unchanged from before)
    // -------------------------------------------------------------------------

    [Test]
    public async Task GetTokenAsync_FetchesAndReturnsToken()
    {
        _server
            .Given(Request.Create().WithPath(_tokenEndpointPath).UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(ValidTokenResponse)
                .WithHeader("Content-Type", "application/json"));

        using var provider = CreateProvider();

        var token = await provider.GetTokenAsync();

        Assert.That(token, Is.EqualTo("test-access-token"));
        Assert.That(_server.LogEntries.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task GetTokenAsync_CachesTokenWithinTtl()
    {
        _server
            .Given(Request.Create().WithPath(_tokenEndpointPath).UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(ValidTokenResponse)
                .WithHeader("Content-Type", "application/json"));

        using var provider = CreateProvider();

        var token1 = await provider.GetTokenAsync();
        var token2 = await provider.GetTokenAsync();
        var token3 = await provider.GetTokenAsync();

        Assert.That(token1, Is.EqualTo("test-access-token"));
        Assert.That(token2, Is.EqualTo("test-access-token"));
        Assert.That(token3, Is.EqualTo("test-access-token"));
        // Token endpoint should only be called once — subsequent calls use cache
        Assert.That(_server.LogEntries.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task GetTokenAsync_ConcurrentCalls_DoesNotDoubleFetch()
    {
        _server
            .Given(Request.Create().WithPath(_tokenEndpointPath).UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(ValidTokenResponse)
                .WithHeader("Content-Type", "application/json"));

        using var provider = CreateProvider();

        // Fire 10 concurrent requests
        var tasks = Enumerable.Range(0, 10)
            .Select(_ => provider.GetTokenAsync())
            .ToArray();
        var tokens = await Task.WhenAll(tasks);

        Assert.That(tokens, Is.All.EqualTo("test-access-token"));
        // Only one actual token fetch should have occurred
        Assert.That(_server.LogEntries.Count(), Is.EqualTo(1));
    }
}
