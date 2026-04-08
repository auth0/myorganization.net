using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.IdentityProviders.Domains;

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
                    .WithPath("/identity-providers/idp_id/domains/domain")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Organization.IdentityProviders.Domains.DeleteAsync("idp_id", "domain")
        );
    }
}
