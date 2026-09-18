using Auth0.MyOrganizationApi.Organization;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Invitations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "invitations": [
                "uinv_0000000000000001",
                "uinv_0000000000000002",
                "uinv_0000000000000003"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/delete-member-invitations")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Organization.Invitations.DeleteAsync(
                new DeleteMemberInvitationsRequestContent
                {
                    Invitations = new List<string>()
                    {
                        "uinv_0000000000000001",
                        "uinv_0000000000000002",
                        "uinv_0000000000000003",
                    },
                }
            )
        );
    }
}
