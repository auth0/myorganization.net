using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Auth0.MyOrganizationApi.Test.Unit.Wrapper;

[TestFixture]
public class MyOrganizationClientTests
{
    private WireMockServer _server = null!;

    private const string OrgDetailsResponse = """
        {
            "name": "testorg",
            "display_name": "Test Organization",
            "branding": {
                "logo_url": "https://example.com/logo.png",
                "colors": {
                    "primary": "#000000",
                    "page_background": "#FFFFFF"
                }
            }
        }
        """;

    [SetUp]
    public void SetUp()
    {
        _server = WireMockServer.Start(new WireMockServerSettings());
    }

    [TearDown]
    public void TearDown()
    {
        _server.Stop();
        _server.Dispose();
    }

    [Test]
    public void Constructor_NullOptions_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new MyOrganizationClient(null!));
    }

    [Test]
    public void Constructor_NullTokenProvider_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new MyOrganizationClient(new MyOrganizationClientOptions
            {
                TokenProvider = null!
            }));
    }

    [Test]
    public void Constructor_NoDomainOrBaseUrl_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new MyOrganizationClient(new MyOrganizationClientOptions
            {
                TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("token")),
            }));
    }

    [Test]
    public async Task Request_IncludesBearerAuthorizationHeader()
    {
        _server
            .Given(Request.Create().WithPath("/details").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(OrgDetailsResponse));

        using var client = new MyOrganizationClient(new MyOrganizationClientOptions
        {
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("my-dynamic-token")),
            BaseUrl = _server.Urls[0],
            MaxRetries = 0,
        });

        await client.OrganizationDetails.GetAsync();

        var logEntry = _server.LogEntries.Single();
        Assert.That(
            logEntry.RequestMessage.Headers!["Authorization"].First(),
            Is.EqualTo("Bearer my-dynamic-token"));
    }

    [Test]
    public async Task Request_TokenFetchedFreshOnEveryRequest()
    {
        _server
            .Given(Request.Create().WithPath("/details").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(OrgDetailsResponse));

        var callCount = 0;
        using var client = new MyOrganizationClient(new MyOrganizationClientOptions
        {
            TokenProvider = new DelegateTokenProvider(_ =>
            {
                callCount++;
                return Task.FromResult($"token-{callCount}");
            }),
            BaseUrl = _server.Urls[0],
            MaxRetries = 0,
        });

        await client.OrganizationDetails.GetAsync();
        await client.OrganizationDetails.GetAsync();

        // Token delegate should be called once per request
        Assert.That(callCount, Is.EqualTo(2));
        var entries = _server.LogEntries.ToList();
        Assert.That(entries[0].RequestMessage.Headers!["Authorization"].First(), Is.EqualTo("Bearer token-1"));
        Assert.That(entries[1].RequestMessage.Headers!["Authorization"].First(), Is.EqualTo("Bearer token-2"));
    }

    [Test]
    public async Task Request_AdditionalHeadersAreSent()
    {
        _server
            .Given(Request.Create().WithPath("/details").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(OrgDetailsResponse));

        using var client = new MyOrganizationClient(new MyOrganizationClientOptions
        {
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("token")),
            BaseUrl = _server.Urls[0],
            MaxRetries = 0,
            AdditionalHeaders = new Dictionary<string, string>
            {
                { "X-Custom-Header", "custom-value" }
            }
        });

        await client.OrganizationDetails.GetAsync();

        var logEntry = _server.LogEntries.Single();
        Assert.That(
            logEntry.RequestMessage.Headers!["X-Custom-Header"].First(),
            Is.EqualTo("custom-value"));
    }


    [Test]
    public async Task Request_BaseUrlTakesPrecedenceOverDomain()
    {
        _server
            .Given(Request.Create().WithPath("/custom-base/details").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(OrgDetailsResponse));

        using var client = new MyOrganizationClient(new MyOrganizationClientOptions
        {
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("token")),
            Domain = "should.be.ignored.auth0.com",
            BaseUrl = $"{_server.Urls[0]}/custom-base",
            MaxRetries = 0,
        });

        await client.OrganizationDetails.GetAsync();

        var logEntry = _server.LogEntries.Single();
        Assert.That(logEntry.RequestMessage.Path, Is.EqualTo("/custom-base/details"));
    }

    [TestCase("https://tenant.auth0.com")]
    [TestCase("http://tenant.auth0.com")]
    [TestCase("HTTPS://tenant.auth0.com")]
    public void Constructor_DomainWithScheme_ThrowsArgumentException(string domain)
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            new MyOrganizationClient(new MyOrganizationClientOptions
            {
                TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("token")),
                Domain = domain,
            }));
        Assert.That(ex!.ParamName, Is.EqualTo(nameof(MyOrganizationClientOptions.Domain)));
    }

    [TestCase("tenant.auth0.com/")]
    [TestCase("tenant.auth0.com/my-org")]
    public void Constructor_DomainWithSlash_ThrowsArgumentException(string domain)
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            new MyOrganizationClient(new MyOrganizationClientOptions
            {
                TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("token")),
                Domain = domain,
            }));
        Assert.That(ex!.ParamName, Is.EqualTo(nameof(MyOrganizationClientOptions.Domain)));
    }

    [TestCase(" tenant.auth0.com ")]
    [TestCase("\ttenant.auth0.com\t")]
    public void Constructor_DomainWithWhitespace_DoesNotThrow(string domain)
    {
        Assert.DoesNotThrow(() =>
        {
            using var client = new MyOrganizationClient(new MyOrganizationClientOptions
            {
                TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("token")),
                Domain = domain,
            });
        });
    }

    [Test]
    public void Constructor_DomainWithScheme_WhenBaseUrlAlsoSet_DoesNotThrow()
    {
        // BaseUrl takes precedence; Domain is ignored so no validation runs on it
        Assert.DoesNotThrow(() =>
        {
            using var client = new MyOrganizationClient(new MyOrganizationClientOptions
            {
                TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("token")),
                Domain = "https://tenant.auth0.com",
                BaseUrl = "https://tenant.auth0.com/my-org",
            });
        });
    }

    [Test]
    public void Dispose_DoesNotThrow()
    {
        var client = new MyOrganizationClient(new MyOrganizationClientOptions
        {
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("token")),
            Domain = "tenant.auth0.com",
        });

        Assert.DoesNotThrow(() => client.Dispose());
    }

    [Test]
    public void Dispose_WithProvidedHttpClient_DoesNotDisposeIt()
    {
        // When caller provides HttpClient, MyOrganizationClient must not own/dispose it
        var httpClient = new HttpClient();
        var client = new MyOrganizationClient(new MyOrganizationClientOptions
        {
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("token")),
            Domain = "tenant.auth0.com",
            HttpClient = httpClient,
        });

        client.Dispose();

        // HttpClient should still be usable after client is disposed
        Assert.DoesNotThrow(() => httpClient.BaseAddress = new Uri("https://example.com"));
        httpClient.Dispose();
    }
}
