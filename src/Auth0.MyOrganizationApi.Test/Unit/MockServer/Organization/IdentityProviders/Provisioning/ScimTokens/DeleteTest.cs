using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.IdentityProviders.Provisioning.ScimTokens;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/identity-providers/idp_id/provisioning/scim-tokens/idp_scim_token_id"
                    )
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Organization.IdentityProviders.Provisioning.ScimTokens.DeleteAsync(
                "idp_id",
                "idp_scim_token_id"
            )
        );
    }
}
