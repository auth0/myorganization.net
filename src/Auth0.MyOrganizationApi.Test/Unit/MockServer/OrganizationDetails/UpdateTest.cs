using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.OrganizationDetails;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "testorg",
              "display_name": "Test Organization",
              "branding": {
                "logo_url": "https://example.com/logo.png",
                "colors": {
                  "primary": "#000000",
                  "page_background": "#FFFFFF"
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "name": "testorg",
              "display_name": "Test Organization",
              "branding": {
                "logo_url": "https://example.com/logo.png",
                "colors": {
                  "primary": "#000000",
                  "page_background": "#FFFFFF"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/details")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OrganizationDetails.UpdateAsync(
            new OrgDetails
            {
                Name = "testorg",
                DisplayName = "Test Organization",
                Branding = new OrgBranding
                {
                    LogoUrl = "https://example.com/logo.png",
                    Colors = new OrgBrandingColors
                    {
                        Primary = "#000000",
                        PageBackground = "#FFFFFF",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
