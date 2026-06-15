using Auth0.MyOrganizationApi.Organization.Members;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Members.Roles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "next": "next",
              "roles": [
                {
                  "id": "rol_SO2j0sFo9NFa3F9w",
                  "name": "role1",
                  "description": "role1 description"
                },
                {
                  "id": "rol_BO2j1sFo9NFa3F9w",
                  "name": "role2",
                  "description": "role2 description"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/members/user_id/roles")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Organization.Members.Roles.ListAsync(
            "user_id",
            new ListOrgMemberRolesRequestParameters { From = "from", Take = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
