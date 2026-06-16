using Auth0.MyOrganizationApi.Organization;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Roles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "roles": [
                {
                  "id": "rol_BKI0BKI0BKI0BKI0",
                  "name": "Admin",
                  "description": "Administrator role with full access"
                },
                {
                  "id": "rol_BKI0BKI0BKI0BKI1",
                  "name": "User",
                  "description": "Standard user role with limited access"
                }
              ],
              "next": "abc123"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/roles")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("name", "name")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Organization.Roles.ListAsync(
            new ListRolesRequestParameters
            {
                From = "from",
                Take = 1,
                Name = "name",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
