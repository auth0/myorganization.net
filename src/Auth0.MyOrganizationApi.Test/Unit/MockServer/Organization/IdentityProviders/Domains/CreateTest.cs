using Auth0.MyOrganizationApi.Organization.IdentityProviders;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.IdentityProviders.Domains;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "domain": "my-domain.com"
            }
            """;

        const string mockResponse = """
            {
              "domain": "my-domain.com"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/identity-providers/idp_id/domains")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.IdentityProviders.Domains.CreateAsync(
            "idp_id",
            new CreateIdpDomainRequestContent { Domain = "my-domain.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
