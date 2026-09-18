using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Organization;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.UserStores;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "user_stores": [
                {
                  "id": "con_abc123",
                  "name": "acme-scim",
                  "display_name": "Acme SCIM",
                  "access_level": "full",
                  "member_access_level": "full",
                  "is_enabled": true
                }
              ]
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/user-stores").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.UserStores.ListAsync(
            new ListOrganizationUserStoresRequestParameters
            {
                MemberAccessLevel =
                [
                    new List<OrganizationAccessLevelEnum?>() { OrganizationAccessLevelEnum.None },
                ],
                IsEnabled = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
