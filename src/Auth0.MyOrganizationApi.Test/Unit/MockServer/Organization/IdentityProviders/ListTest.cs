using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.IdentityProviders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "identity_providers": [
                {
                  "id": "con_zW1UHutvkVWSWdCC",
                  "name": "oidcIdp",
                  "strategy": "oidc",
                  "domains": [
                    "mydomain.com"
                  ],
                  "display_name": "OIDC IdP",
                  "show_as_button": true,
                  "assign_membership_on_login": false,
                  "is_enabled": true,
                  "access_level": "full",
                  "options": {
                    "type": "front_channel",
                    "client_id": "a8f3b2e7-5d1c-4f9a-8b0d-2e1c3a5b6f7d",
                    "discovery_url": "https://{yourDomain}/.well-known/openid-configuration"
                  },
                  "attributes": [
                    {
                      "user_attribute": "preferred_username",
                      "description": "Preferred Username",
                      "label": "Preferred username",
                      "is_required": true,
                      "is_extra": false,
                      "is_missing": false,
                      "sso_field": [
                        "userName"
                      ]
                    },
                    {
                      "user_attribute": "external_id",
                      "is_required": true,
                      "is_extra": true,
                      "is_missing": false,
                      "sso_field": [
                        "externalId"
                      ]
                    }
                  ]
                },
                {
                  "id": "con_zW1UHutvkVWSWdCD",
                  "name": "samlIdp",
                  "strategy": "samlp",
                  "domains": [
                    "mydomain.com"
                  ],
                  "display_name": "Saml IdP",
                  "show_as_button": true,
                  "assign_membership_on_login": false,
                  "is_enabled": true,
                  "access_level": "limited",
                  "options": {
                    "metadataUrl": "a.metadata.url",
                    "signSAMLRequest": true,
                    "signatureAlgorithm": "rsa-sha256",
                    "digestAlgorithm": "sha256",
                    "protocolBinding": "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST",
                    "bindingMethod": "HTTP-Redirect",
                    "cert": "MIIDQjCCAiugAwIBAgIRAMp+cW+SgQ2Yh7fF8v8b0OQwDQYJKoZIhvcNAQELBQAw...",
                    "idpInitiated": {
                      "enabled": true,
                      "client_id": "a8f3b2e7-5d1c-4f9a-8b0d-2e1c3a5b6f7d",
                      "client_protocol": "SAML",
                      "client_authorizequery": "redirect_uri=https://jwt.io&scope=openid email&response_type=token"
                    }
                  },
                  "attributes": [
                    {
                      "user_attribute": "preferred_username",
                      "description": "Preferred Username",
                      "label": "Preferred username",
                      "is_required": true,
                      "is_extra": false,
                      "is_missing": false,
                      "sso_field": [
                        "userName"
                      ]
                    },
                    {
                      "user_attribute": "external_id",
                      "is_required": true,
                      "is_extra": true,
                      "is_missing": false,
                      "sso_field": [
                        "externalId"
                      ]
                    }
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/identity-providers").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.IdentityProviders.ListAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
