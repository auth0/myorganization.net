using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.IdentityProviders.Provisioning;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "strategy": "okta",
              "method": "scim",
              "attributes": [
                {
                  "user_attribute": "preferred_username",
                  "description": "Preferred Username",
                  "label": "Preferred username",
                  "is_required": true,
                  "is_extra": false,
                  "is_missing": false,
                  "provisioning_field": "userName"
                },
                {
                  "user_attribute": "external_id",
                  "description": "description",
                  "label": "label",
                  "is_required": true,
                  "is_extra": true,
                  "is_missing": false,
                  "provisioning_field": "externalId"
                }
              ],
              "user_id_attribute": "externalId",
              "created_at": "2025-05-15T23:32:52.000Z",
              "updated_on": "2025-05-15T23:32:52.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/identity-providers/idp_id/provisioning")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.IdentityProviders.Provisioning.CreateAsync(
            "idp_id"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
