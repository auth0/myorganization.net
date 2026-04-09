using Auth0.MyOrganizationApi.Organization;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Domains;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "next": "eyJpZCI6Im9yZF96VzFVSGV0dmtCV1NXZENEZThEV3E3IiwidGVuYW50IjoidGVzdC10ZW5hbnQifQ",
              "organization_domains": [
                {
                  "domain": "acme.com",
                  "status": "pending",
                  "verification_txt": "dove_text=asdfpiujnlewp-23849jdkfjzxcfpiawer",
                  "verification_host": "_ss-verification.org_zW1UHutvkVWSWdCC.acme.com"
                },
                {
                  "domain": "roadrunner.com",
                  "status": "failed",
                  "verification_txt": "dove_text=bcxzpiujnlewp-23849jdkfjzxcfpiawer",
                  "verification_host": "_ss-verification.org_nW1UHutvkVWSWdCG.acme.com"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/domains")
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

        var items = await Client.Organization.Domains.ListAsync(
            new ListOrganizationDomainsRequestParameters { From = "from", Take = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
