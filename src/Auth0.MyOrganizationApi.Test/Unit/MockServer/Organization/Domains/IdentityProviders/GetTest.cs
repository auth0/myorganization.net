using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Domains.IdentityProviders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "identity_providers": [
                {
                  "name": "acme-engineering",
                  "display_name": "Acme Engineering"
                },
                {
                  "name": "acme-engineering-2",
                  "display_name": "Acme Engineering 2"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/domains/domain_id/identity-providers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.Domains.IdentityProviders.GetAsync("domain_id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
