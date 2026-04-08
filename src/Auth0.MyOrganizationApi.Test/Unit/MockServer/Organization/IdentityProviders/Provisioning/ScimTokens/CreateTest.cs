using Auth0.MyOrganizationApi.Organization.IdentityProviders.Provisioning;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.IdentityProviders.Provisioning.ScimTokens;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "token_lifetime": 86400
            }
            """;

        const string mockResponse = """
            {
              "token_id": "tok_tuz8H9hWQ8LaCkdh",
              "scopes": [
                "scopes"
              ],
              "created_at": "2025-04-11T20:11:45.000Z",
              "valid_until": "2025-04-12T20:11:45.000Z",
              "token": "tok_tuz8H9hWQ8LaCkdh...."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/identity-providers/idp_id/provisioning/scim-tokens")
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

        var response =
            await Client.Organization.IdentityProviders.Provisioning.ScimTokens.CreateAsync(
                "idp_id",
                new CreateIdpProvisioningScimTokenRequestContent { TokenLifetime = 86400 }
            );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
