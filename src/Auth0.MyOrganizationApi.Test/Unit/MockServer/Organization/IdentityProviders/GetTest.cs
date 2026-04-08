using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.IdentityProviders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "con_zW1UHutvkVWSWdCC",
              "name": "oidcIdp",
              "strategy": "oidc",
              "domains": [
                "mydomain.com"
              ],
              "display_name": "OIDC IdP",
              "show_as_button": true,
              "assign_membership_on_login": false,
              "is_enabled": true,
              "access_level": "readonly",
              "options": {
                "type": "front_channel",
                "client_id": "a8f3b2e7-5d1c-4f9a-8b0d-2e1c3a5b6f7d",
                "discovery_url": "https://{yourDomain}/.well-known/openid-configuration"
              },
              "attributes": [
                {
                  "user_attribute": "preferred_username",
                  "description": "Preferred Username",
                  "label": "Preferred username",
                  "is_required": true,
                  "is_extra": false,
                  "is_missing": false,
                  "sso_field": [
                    "userName"
                  ]
                },
                {
                  "user_attribute": "external_id",
                  "description": "description",
                  "label": "label",
                  "is_required": true,
                  "is_extra": true,
                  "is_missing": false,
                  "sso_field": [
                    "externalId"
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/identity-providers/idp_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.IdentityProviders.GetAsync("idp_id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
