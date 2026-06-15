using Auth0.MyOrganizationApi.Organization;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Invitations;

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
              "invitations": [
                {
                  "inviter": {
                    "name": "Allison the Admin"
                  },
                  "invitee": {
                    "email": "user@example.com"
                  },
                  "created_at": "2025-04-11T20:11:45.000Z",
                  "expires_at": "2025-04-11T20:11:45.000Z",
                  "invitation_url": "https://example.auth0.com/login?invitation=uinv_12345678abcdefgh&organization=org_12345678abcdefgh",
                  "ticket_id": "1asdfasd23usjdef"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/member-invitations")
                    .WithParam("fields", "fields")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("sort", "sort")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Organization.Invitations.ListAsync(
            new ListMemberInvitationsRequestParameters
            {
                Fields = "fields",
                IncludeFields = true,
                From = "from",
                Take = 1,
                Sort = "sort",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
