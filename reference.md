# Reference
## OrganizationDetails
<details><summary><code>client.OrganizationDetails.<a href="/src/Auth0.MyOrganizationApi/OrganizationDetails/OrganizationDetailsClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;OrgDetailsRead&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details for an Organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OrganizationDetails.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.OrganizationDetails.<a href="/src/Auth0.MyOrganizationApi/OrganizationDetails/OrganizationDetailsClient.cs">UpdateAsync</a>(OrgDetails { ... }) -> WithRawResponseTask&lt;OrgDetailsRead&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the details of a specific Organization, such as display name and branding options.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OrganizationDetails.UpdateAsync(
    new OrgDetails
    {
        Name = "testorg",
        DisplayName = "Test Organization",
        Branding = new OrgBranding
        {
            LogoUrl = "https://example.com/logo.png",
            Colors = new OrgBrandingColors { Primary = "#000000", PageBackground = "#FFFFFF" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `OrgDetails` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization Configuration
<details><summary><code>client.Organization.Configuration.<a href="/src/Auth0.MyOrganizationApi/Organization/Configuration/ConfigurationClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetConfigurationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the configuration for the /my-org API. This will return all stored client information with the exception of attributes that are identifiers. Identifier attributes will be given their own endpoint that will return the full object. This will give the components all of the information they will need to be successful. The SDK provider for the components should manage fetching and caching this information for all components.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.Configuration.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization Domains
<details><summary><code>client.Organization.Domains.<a href="/src/Auth0.MyOrganizationApi/Organization/Domains/DomainsClient.cs">ListAsync</a>() -> WithRawResponseTask&lt;ListOrganizationDomainsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all domains pending and verified for an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.Domains.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.Domains.<a href="/src/Auth0.MyOrganizationApi/Organization/Domains/DomainsClient.cs">CreateAsync</a>(CreateOrganizationDomainRequestContent { ... }) -> WithRawResponseTask&lt;OrgDomain&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new domain for an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.Domains.CreateAsync(
    new CreateOrganizationDomainRequestContent { Domain = "acme.com" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateOrganizationDomainRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.Domains.<a href="/src/Auth0.MyOrganizationApi/Organization/Domains/DomainsClient.cs">GetAsync</a>(domainId) -> WithRawResponseTask&lt;OrgDomain&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a domain for an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.Domains.GetAsync("domain_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domainId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.Domains.<a href="/src/Auth0.MyOrganizationApi/Organization/Domains/DomainsClient.cs">DeleteAsync</a>(domainId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove a domain from this organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.Domains.DeleteAsync("domain_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domainId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization IdentityProviders
<details><summary><code>client.Organization.IdentityProviders.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/IdentityProvidersClient.cs">ListAsync</a>() -> WithRawResponseTask&lt;ListIdentityProvidersResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List the identity providers associated with this organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/IdentityProvidersClient.cs">CreateAsync</a>(IdpKnownRequest { ... }) -> WithRawResponseTask&lt;IdpKnownResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create an identity provider associated with this organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.CreateAsync(
    new IdpOidcRequest
    {
        Name = "oidcIdp",
        Strategy = IdpOidcRequestStrategy.Oidc,
        Domains = new List<string>() { "mydomain.com" },
        DisplayName = "OIDC IdP",
        ShowAsButton = true,
        AssignMembershipOnLogin = false,
        IsEnabled = true,
        Options = new IdpOidcOptionsRequest
        {
            Type = IdpOidcOptionsTypeEnum.FrontChannel,
            ClientId = "a8f3b2e7-5d1c-4f9a-8b0d-2e1c3a5b6f7d",
            ClientSecret = "KzQp2sVxR8nTgMjFhYcEWuLoIbDvUoC6A9B1zX7yWqFjHkGrP5sQdLmNp",
            DiscoveryUrl = "https://{yourDomain}/.well-known/openid-configuration",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IdpKnownRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/IdentityProvidersClient.cs">GetAsync</a>(idpId) -> WithRawResponseTask&lt;IdpKnownResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the details for one particular identity-provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.GetAsync("idp_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/IdentityProvidersClient.cs">DeleteAsync</a>(idpId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete an identity provider from this organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.DeleteAsync("idp_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/IdentityProvidersClient.cs">UpdateAsync</a>(idpId, IdpUpdateKnownRequest { ... }) -> WithRawResponseTask&lt;IdpUpdateKnownResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an identity provider associated with this organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.UpdateAsync(
    "idp_id",
    new IdpOidcUpdateRequest
    {
        DisplayName = "OIDC IdP",
        ShowAsButton = true,
        AssignMembershipOnLogin = false,
        IsEnabled = true,
        Options = new IdpOidcOptionsRequest
        {
            Type = IdpOidcOptionsTypeEnum.FrontChannel,
            ClientId = "a8f3b2e7-5d1c-4f9a-8b0d-2e1c3a5b6f7d",
            ClientSecret = "KzQp2sVxR8nTgMjFhYcEWuLoIbDvUoC6A9B1zX7yWqFjHkGrP5sQdLmNp",
            DiscoveryUrl = "https://{yourDomain}/.well-known/openid-configuration",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `IdpUpdateKnownRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/IdentityProvidersClient.cs">UpdateAttributesAsync</a>(idpId, Dictionary&lt;string, object?&gt; { ... }) -> WithRawResponseTask&lt;IdpKnownResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Triggers a refresh of attribute mappings on the identity provider by overriding it with the admin defined defaults. The endpoint doesn't accept any body parameters.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.UpdateAttributesAsync(
    "idp_id",
    new Dictionary<string, object?>() { { "key", "value" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `Dictionary<string, object?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/IdentityProvidersClient.cs">DetachAsync</a>(idpId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete underlying identity provider from this organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.DetachAsync("idp_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization Configuration IdentityProviders
<details><summary><code>client.Organization.Configuration.IdentityProviders.<a href="/src/Auth0.MyOrganizationApi/Organization/Configuration/IdentityProviders/IdentityProvidersClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;IdentityProvidersConfig&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the connection profile for the application. This will give the components all of the information they will need to be successful. The SDK provider for the components should manage fetching and caching this information for all components.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.Configuration.IdentityProviders.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization Domains Verify
<details><summary><code>client.Organization.Domains.Verify.<a href="/src/Auth0.MyOrganizationApi/Organization/Domains/Verify/VerifyClient.cs">CreateAsync</a>(domainId) -> WithRawResponseTask&lt;OrgDomain&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a verification text and start the domain verification process for a particular domain.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.Domains.Verify.CreateAsync("domain_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domainId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization Domains IdentityProviders
<details><summary><code>client.Organization.Domains.IdentityProviders.<a href="/src/Auth0.MyOrganizationApi/Organization/Domains/IdentityProviders/IdentityProvidersClient.cs">GetAsync</a>(domainId) -> WithRawResponseTask&lt;ListDomainIdentityProvidersResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the list of identity providers that have a specific organization domain alias.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.Domains.IdentityProviders.GetAsync("domain_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domainId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization IdentityProviders Domains
<details><summary><code>client.Organization.IdentityProviders.Domains.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/Domains/DomainsClient.cs">CreateAsync</a>(idpId, CreateIdpDomainRequestContent { ... }) -> WithRawResponseTask&lt;CreateIdpDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Add a domain to the identity provider's list of domains for [Home Realm Discovery (HRD)](https://auth0.com/docs/get-started/architecture-scenarios/business-to-business/authentication#home-realm-discovery). The domain passed must be claimed and verified by this organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.Domains.CreateAsync(
    "idp_id",
    new CreateIdpDomainRequestContent { Domain = "my-domain.com" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateIdpDomainRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.Domains.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/Domains/DomainsClient.cs">DeleteAsync</a>(idpId, domain)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove a domain from an identity provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.Domains.DeleteAsync("idp_id", "domain");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**domain:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization IdentityProviders Provisioning
<details><summary><code>client.Organization.IdentityProviders.Provisioning.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/Provisioning/ProvisioningClient.cs">GetAsync</a>(idpId) -> WithRawResponseTask&lt;GetIdPProvisioningConfigResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the Provisioning configuration for this identity provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.Provisioning.GetAsync("idp_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.Provisioning.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/Provisioning/ProvisioningClient.cs">CreateAsync</a>(idpId) -> WithRawResponseTask&lt;CreateIdPProvisioningConfigResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create the Provisioning configuration for this identity provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.Provisioning.CreateAsync("idp_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.Provisioning.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/Provisioning/ProvisioningClient.cs">DeleteAsync</a>(idpId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete the Provisioning configuration for an identity provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.Provisioning.DeleteAsync("idp_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.Provisioning.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/Provisioning/ProvisioningClient.cs">UpdateAttributesAsync</a>(idpId, Dictionary&lt;string, object?&gt; { ... }) -> WithRawResponseTask&lt;GetIdPProvisioningConfigResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Triggers a refresh of attribute mappings on the provisioning configuration by overriding it with the admin defined defaults. The endpoint doesn't accept any body parameters.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.Provisioning.UpdateAttributesAsync(
    "idp_id",
    new Dictionary<string, object?>() { { "key", "value" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `Dictionary<string, object?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization IdentityProviders Provisioning ScimTokens
<details><summary><code>client.Organization.IdentityProviders.Provisioning.ScimTokens.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/Provisioning/ScimTokens/ScimTokensClient.cs">ListAsync</a>(idpId) -> WithRawResponseTask&lt;ListIdpProvisioningScimTokensResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List the Provisioning SCIM tokens for this identity provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.Provisioning.ScimTokens.ListAsync("idp_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.Provisioning.ScimTokens.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/Provisioning/ScimTokens/ScimTokensClient.cs">CreateAsync</a>(idpId, CreateIdpProvisioningScimTokenRequestContent { ... }) -> WithRawResponseTask&lt;IdpScimTokenCreate&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a Provisioning SCIM token for this identity provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.Provisioning.ScimTokens.CreateAsync(
    "idp_id",
    new CreateIdpProvisioningScimTokenRequestContent { TokenLifetime = 86400 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateIdpProvisioningScimTokenRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.IdentityProviders.Provisioning.ScimTokens.<a href="/src/Auth0.MyOrganizationApi/Organization/IdentityProviders/Provisioning/ScimTokens/ScimTokensClient.cs">DeleteAsync</a>(idpId, idpScimTokenId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a Provisioning SCIM configuration for an identity provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.IdentityProviders.Provisioning.ScimTokens.DeleteAsync(
    "idp_id",
    "idp_scim_token_id"
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idpId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**idpScimTokenId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

