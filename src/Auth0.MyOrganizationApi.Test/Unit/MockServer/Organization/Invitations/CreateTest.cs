using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Organization;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Invitations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "invitees": [
                {
                  "email": "user@example.com",
                  "roles": [
                    "rol_0000000000000001"
                  ]
                }
              ],
              "inviter": {
                "name": "Allison the Admin"
              },
              "identity_provider_id": "con_2CZPv6IY0gWzDaQJ",
              "ttl_sec": 3600
            }
            """;

        const string mockResponse = """
            [
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/member-invitations")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.Invitations.CreateAsync(
            new CreateMemberInvitationRequestContent
            {
                Invitees = new List<CreateMemberInvitationInvitee>()
                {
                    new CreateMemberInvitationInvitee
                    {
                        Email = "user@example.com",
                        Roles = new List<string>() { "rol_0000000000000001" },
                    },
                },
                Inviter = new MemberInvitationInviter { Name = "Allison the Admin" },
                IdentityProviderId = "con_2CZPv6IY0gWzDaQJ",
                TtlSec = 3600,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
