using System.Text;
using System.Text.Json;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Auth0.MyOrganizationApi.Test.Core;

/// <summary>
/// Verifies the <c>Auth0-Client</c> telemetry header is present on every flow that can reach
/// the wire: the low-level client, the <see cref="MyOrganizationClient"/> wrapper, retried
/// attempts, and requests carrying per-request options.
/// </summary>
[TestFixture]
public class TelemetryTests
{
    private const string HeaderName = "Auth0-Client";

    private const string OrgDetailsResponse = """
        { "name": "testorg", "display_name": "Test Organization" }
        """;

    private WireMockServer _server = null!;

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

    private void StubDetails() =>
        _server
            .Given(Request.Create().WithPath("/details").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(OrgDetailsResponse));

    private static void AssertWellFormed(string headerValue)
    {
        Assert.That(headerValue, Does.Not.Contain("=").And.Not.Contain("+").And.Not.Contain("/"));

        var padded = headerValue.Replace('-', '+').Replace('_', '/');
        padded = padded.PadRight(padded.Length + ((4 - (padded.Length % 4)) % 4), '=');
        using var json = JsonDocument.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(padded)));

        Assert.That(json.RootElement.GetProperty("name").GetString(), Is.EqualTo("MyOrganization.NET"));
        Assert.That(json.RootElement.GetProperty("version").GetString(), Is.Not.Empty);
        Assert.That(
            json.RootElement.GetProperty("env").GetProperty("target").GetString(),
            Is.Not.EqualTo("UNKNOWN")
        );
    }

    [Test]
    public void NewClientOptions_SeedsTelemetryHeader()
    {
        var options = new ClientOptions();

        Assert.That(options.Headers.ContainsKey(HeaderName), Is.True);
    }

    [Test]
    public async Task LowLevelClient_SendsTelemetryHeader()
    {
        StubDetails();
        var client = new MyOrganizationApiClient(
            "token",
            new ClientOptions { BaseUrl = _server.Urls[0], MaxRetries = 0 }
        );

        await client.OrganizationDetails.GetAsync();

        AssertWellFormed(_server.LogEntries.Single().RequestMessage.Headers![HeaderName].First());
    }

    [Test]
    public async Task WrapperClient_SendsTelemetryHeader()
    {
        StubDetails();
        using var client = new MyOrganizationClient(
            new MyOrganizationClientOptions
            {
                TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("token")),
                BaseUrl = _server.Urls[0],
                MaxRetries = 0,
            }
        );

        await client.OrganizationDetails.GetAsync();

        AssertWellFormed(_server.LogEntries.Single().RequestMessage.Headers![HeaderName].First());
    }

    [Test]
    public async Task RequestOptions_StillSendTelemetryHeader()
    {
        StubDetails();
        var client = new MyOrganizationApiClient(
            "token",
            new ClientOptions { BaseUrl = _server.Urls[0], MaxRetries = 0 }
        );

        await client.OrganizationDetails.GetAsync(
            new RequestOptions
            {
                AdditionalHeaders = new Dictionary<string, string?> { { "X-Request", "scoped" } },
            }
        );

        var entry = _server.LogEntries.Single();
        Assert.That(entry.RequestMessage.Headers!["X-Request"].First(), Is.EqualTo("scoped"));
        AssertWellFormed(entry.RequestMessage.Headers![HeaderName].First());
    }

    [Test]
    public async Task CallerSuppliedTelemetryHeader_TakesPrecedence()
    {
        StubDetails();
        var client = new MyOrganizationApiClient(
            "token",
            new ClientOptions
            {
                BaseUrl = _server.Urls[0],
                MaxRetries = 0,
                AdditionalHeaders = new Dictionary<string, string?> { { HeaderName, "caller-supplied" } },
            }
        );

        await client.OrganizationDetails.GetAsync();

        // AdditionalHeaders are applied after Options.Headers, so a caller can still override.
        Assert.That(
            _server.LogEntries.Single().RequestMessage.Headers![HeaderName].Single(),
            Is.EqualTo("caller-supplied")
        );
    }

    [Test]
    public async Task RetriedRequests_AllCarryTelemetryHeader()
    {
        _server
            .Given(Request.Create().WithPath("/details").UsingGet())
            .InScenario("Retry")
            .WillSetStateTo("Failed")
            .RespondWith(Response.Create().WithStatusCode(500));
        _server
            .Given(Request.Create().WithPath("/details").UsingGet())
            .InScenario("Retry")
            .WhenStateIs("Failed")
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(OrgDetailsResponse));

        var client = new MyOrganizationApiClient(
            "token",
            new ClientOptions { BaseUrl = _server.Urls[0], MaxRetries = 2 }
        );

        await client.OrganizationDetails.GetAsync();

        var entries = _server.LogEntries.ToList();
        Assert.That(entries, Has.Count.GreaterThan(1), "Expected at least one retry.");
        foreach (var entry in entries)
        {
            AssertWellFormed(entry.RequestMessage.Headers![HeaderName].First());
        }
    }
}
