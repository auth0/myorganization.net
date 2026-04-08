using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.IdentityProviders.Provisioning.ScimTokens;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "scim_tokens": [
                {
                  "token_id": "tok_abc8H9hWQ8LaCkdh",
                  "scopes": [
                    "scopes"
                  ],
                  "created_at": "2025-05-11T20:11:45.000Z",
                  "valid_until": "2025-05-11T20:26:45.000Z"
                },
                {
                  "token_id": "tok_tuz8H9hWQ8LaCkdh",
                  "scopes": [
                    "scopes"
                  ],
                  "created_at": "2025-04-11T20:11:45.000Z",
                  "valid_until": "2025-04-12T20:11:45.000Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/identity-providers/idp_id/provisioning/scim-tokens")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response =
            await Client.Organization.IdentityProviders.Provisioning.ScimTokens.ListAsync("idp_id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
