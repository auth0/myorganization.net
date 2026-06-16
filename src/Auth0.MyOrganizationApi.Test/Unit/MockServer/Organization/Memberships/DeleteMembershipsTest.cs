using Auth0.MyOrganizationApi.Organization;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Memberships;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteMembershipsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "members": [
                "auth0|1234567890"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/delete-memberships")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Organization.Memberships.DeleteMembershipsAsync(
                new DeleteOrganizationMembershipsRequestParameters
                {
                    Members = new List<string>() { "auth0|1234567890" },
                }
            )
        );
    }
}
