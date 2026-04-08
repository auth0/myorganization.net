using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.IdentityProviders.Provisioning;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateAttributesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "key": "value"
            }
            """;

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
                  "user_attribute": "blocked",
                  "description": "description",
                  "label": "label",
                  "is_required": true,
                  "is_extra": false,
                  "is_missing": false,
                  "provisioning_field": "active"
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
                    .WithPath("/identity-providers/idp_id/provisioning/update-attributes")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response =
            await Client.Organization.IdentityProviders.Provisioning.UpdateAttributesAsync(
                "idp_id",
                new Dictionary<string, object?>() { { "key", "value" } }
            );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
