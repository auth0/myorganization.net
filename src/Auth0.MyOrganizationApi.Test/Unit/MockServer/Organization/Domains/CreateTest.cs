using Auth0.MyOrganizationApi.Organization;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Domains;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "domain": "acme.com"
            }
            """;

        const string mockResponse = """
            {
              "domain": "acme.com",
              "status": "pending",
              "verification_txt": "dove_text=asdfpiujnlewp-23849jdkfjzxcfpiawer",
              "verification_host": "_ss-verification.org_zW1UHutvkVWSWdCC.acme.com"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/domains")
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

        var response = await Client.Organization.Domains.CreateAsync(
            new CreateOrganizationDomainRequestContent { Domain = "acme.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
