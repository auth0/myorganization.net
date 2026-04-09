using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Configuration.IdentityProviders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "organization": {
                "can_set_show_as_button": true,
                "can_set_assign_membership_on_login": false
              },
              "strategies": {
                "adfs": {
                  "enabled_features": [
                    "provisioning"
                  ],
                  "provisioning_methods": [
                    "scim"
                  ]
                },
                "googleapps": {
                  "enabled_features": [
                    "provisioning"
                  ],
                  "provisioning_methods": [
                    "scim"
                  ]
                },
                "oidc": {
                  "enabled_features": [
                    "provisioning"
                  ],
                  "provisioning_methods": [
                    "scim"
                  ]
                },
                "okta": {
                  "enabled_features": [
                    "provisioning",
                    "universal_logout"
                  ],
                  "provisioning_methods": [
                    "scim"
                  ]
                },
                "pingfederate": {
                  "enabled_features": [
                    "provisioning"
                  ],
                  "provisioning_methods": [
                    "scim"
                  ]
                },
                "samlp": {
                  "enabled_features": [
                    "provisioning",
                    "universal_logout"
                  ],
                  "provisioning_methods": [
                    "scim"
                  ]
                },
                "waad": {
                  "enabled_features": [
                    "provisioning"
                  ],
                  "provisioning_methods": [
                    "scim"
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/config/identity-providers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.Configuration.IdentityProviders.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
