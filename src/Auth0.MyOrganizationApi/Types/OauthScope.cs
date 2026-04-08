using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(OauthScope.OauthScopeSerializer))]
[Serializable]
public readonly record struct OauthScope : IStringEnum
{
    /// <summary>
    /// Read organization configuration
    /// </summary>
    public static readonly OauthScope ReadMyOrgConfiguration = new(Values.ReadMyOrgConfiguration);

    /// <summary>
    /// Read organization details
    /// </summary>
    public static readonly OauthScope ReadMyOrgDetails = new(Values.ReadMyOrgDetails);

    /// <summary>
    /// Update organization details
    /// </summary>
    public static readonly OauthScope UpdateMyOrgDetails = new(Values.UpdateMyOrgDetails);

    /// <summary>
    /// Read identity providers for organization
    /// </summary>
    public static readonly OauthScope ReadMyOrgIdentityProviders = new(
        Values.ReadMyOrgIdentityProviders
    );

    /// <summary>
    /// Create identity provider for organization
    /// </summary>
    public static readonly OauthScope CreateMyOrgIdentityProviders = new(
        Values.CreateMyOrgIdentityProviders
    );

    /// <summary>
    /// Update identity provider for organization
    /// </summary>
    public static readonly OauthScope UpdateMyOrgIdentityProviders = new(
        Values.UpdateMyOrgIdentityProviders
    );

    /// <summary>
    /// Delete identity provider for organization
    /// </summary>
    public static readonly OauthScope DeleteMyOrgIdentityProviders = new(
        Values.DeleteMyOrgIdentityProviders
    );

    /// <summary>
    /// Detach identity provider from organization
    /// </summary>
    public static readonly OauthScope UpdateMyOrgIdentityProvidersDetach = new(
        Values.UpdateMyOrgIdentityProvidersDetach
    );

    /// <summary>
    /// Associate organization domain with identity provider
    /// </summary>
    public static readonly OauthScope CreateMyOrgIdentityProvidersDomains = new(
        Values.CreateMyOrgIdentityProvidersDomains
    );

    /// <summary>
    /// Remove organization domain from identity provider
    /// </summary>
    public static readonly OauthScope DeleteMyOrgIdentityProvidersDomains = new(
        Values.DeleteMyOrgIdentityProvidersDomains
    );

    /// <summary>
    /// Create domain for organization
    /// </summary>
    public static readonly OauthScope CreateMyOrgDomains = new(Values.CreateMyOrgDomains);

    /// <summary>
    /// Read domains for organization
    /// </summary>
    public static readonly OauthScope ReadMyOrgDomains = new(Values.ReadMyOrgDomains);

    /// <summary>
    /// Update domain for organization
    /// </summary>
    public static readonly OauthScope UpdateMyOrgDomains = new(Values.UpdateMyOrgDomains);

    /// <summary>
    /// Delete domain for organization
    /// </summary>
    public static readonly OauthScope DeleteMyOrgDomains = new(Values.DeleteMyOrgDomains);

    /// <summary>
    /// Create provisioning configuration for identity provider
    /// </summary>
    public static readonly OauthScope CreateMyOrgIdentityProvidersProvisioning = new(
        Values.CreateMyOrgIdentityProvidersProvisioning
    );

    /// <summary>
    /// Update provisioning configuration for identity provider
    /// </summary>
    public static readonly OauthScope UpdateMyOrgIdentityProvidersProvisioning = new(
        Values.UpdateMyOrgIdentityProvidersProvisioning
    );

    /// <summary>
    /// Read provisioning configuration for identity provider
    /// </summary>
    public static readonly OauthScope ReadMyOrgIdentityProvidersProvisioning = new(
        Values.ReadMyOrgIdentityProvidersProvisioning
    );

    /// <summary>
    /// Delete provisioning configuration for identity provider
    /// </summary>
    public static readonly OauthScope DeleteMyOrgIdentityProvidersProvisioning = new(
        Values.DeleteMyOrgIdentityProvidersProvisioning
    );

    /// <summary>
    /// Create a provisioning SCIM token for this identity provider
    /// </summary>
    public static readonly OauthScope CreateMyOrgIdentityProvidersScimTokens = new(
        Values.CreateMyOrgIdentityProvidersScimTokens
    );

    /// <summary>
    /// List the provisioning SCIM tokens for this identity provider
    /// </summary>
    public static readonly OauthScope ReadMyOrgIdentityProvidersScimTokens = new(
        Values.ReadMyOrgIdentityProvidersScimTokens
    );

    /// <summary>
    /// Delete a provisioning SCIM configuration for an identity provider
    /// </summary>
    public static readonly OauthScope DeleteMyOrgIdentityProvidersScimTokens = new(
        Values.DeleteMyOrgIdentityProvidersScimTokens
    );

    /// <summary>
    /// List member invitations for organization
    /// </summary>
    public static readonly OauthScope ReadMyOrgMemberInvitations = new(
        Values.ReadMyOrgMemberInvitations
    );

    /// <summary>
    /// Create member invitations for organization
    /// </summary>
    public static readonly OauthScope CreateMyOrgMemberInvitations = new(
        Values.CreateMyOrgMemberInvitations
    );

    /// <summary>
    /// Delete member invitations for organization
    /// </summary>
    public static readonly OauthScope DeleteMyOrgMemberInvitations = new(
        Values.DeleteMyOrgMemberInvitations
    );

    /// <summary>
    /// List members for organization
    /// </summary>
    public static readonly OauthScope ReadMyOrgMembers = new(Values.ReadMyOrgMembers);

    /// <summary>
    /// Delete members from organization
    /// </summary>
    public static readonly OauthScope DeleteMyOrgMembers = new(Values.DeleteMyOrgMembers);

    /// <summary>
    /// List Roles for members in organization
    /// </summary>
    public static readonly OauthScope ReadMyOrgMemberRoles = new(Values.ReadMyOrgMemberRoles);

    /// <summary>
    /// Create Roles for members in organization
    /// </summary>
    public static readonly OauthScope CreateMyOrgMemberRoles = new(Values.CreateMyOrgMemberRoles);

    /// <summary>
    /// Update Roles for members in organization
    /// </summary>
    public static readonly OauthScope UpdateMyOrgMemberRoles = new(Values.UpdateMyOrgMemberRoles);

    /// <summary>
    /// Delete Roles from members for organization
    /// </summary>
    public static readonly OauthScope DeleteMyOrgMemberRoles = new(Values.DeleteMyOrgMemberRoles);

    /// <summary>
    /// Create client grants for client in organization
    /// </summary>
    public static readonly OauthScope CreateMyOrgClientGrants = new(Values.CreateMyOrgClientGrants);

    /// <summary>
    /// Create API clients for organization
    /// </summary>
    public static readonly OauthScope CreateMyOrgClients = new(Values.CreateMyOrgClients);

    /// <summary>
    /// Read API clients for organization
    /// </summary>
    public static readonly OauthScope ReadMyOrgClients = new(Values.ReadMyOrgClients);

    /// <summary>
    /// Delete API clients for organization
    /// </summary>
    public static readonly OauthScope DeleteMyOrgClients = new(Values.DeleteMyOrgClients);

    public OauthScope(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static OauthScope FromCustom(string value)
    {
        return new OauthScope(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(OauthScope value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(OauthScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OauthScope value) => value.Value;

    public static explicit operator OauthScope(string value) => new(value);

    internal class OauthScopeSerializer : JsonConverter<OauthScope>
    {
        public override OauthScope Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new OauthScope(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OauthScope value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// Read organization configuration
        /// </summary>
        public const string ReadMyOrgConfiguration = "read:my_org:configuration";

        /// <summary>
        /// Read organization details
        /// </summary>
        public const string ReadMyOrgDetails = "read:my_org:details";

        /// <summary>
        /// Update organization details
        /// </summary>
        public const string UpdateMyOrgDetails = "update:my_org:details";

        /// <summary>
        /// Read identity providers for organization
        /// </summary>
        public const string ReadMyOrgIdentityProviders = "read:my_org:identity_providers";

        /// <summary>
        /// Create identity provider for organization
        /// </summary>
        public const string CreateMyOrgIdentityProviders = "create:my_org:identity_providers";

        /// <summary>
        /// Update identity provider for organization
        /// </summary>
        public const string UpdateMyOrgIdentityProviders = "update:my_org:identity_providers";

        /// <summary>
        /// Delete identity provider for organization
        /// </summary>
        public const string DeleteMyOrgIdentityProviders = "delete:my_org:identity_providers";

        /// <summary>
        /// Detach identity provider from organization
        /// </summary>
        public const string UpdateMyOrgIdentityProvidersDetach =
            "update:my_org:identity_providers_detach";

        /// <summary>
        /// Associate organization domain with identity provider
        /// </summary>
        public const string CreateMyOrgIdentityProvidersDomains =
            "create:my_org:identity_providers_domains";

        /// <summary>
        /// Remove organization domain from identity provider
        /// </summary>
        public const string DeleteMyOrgIdentityProvidersDomains =
            "delete:my_org:identity_providers_domains";

        /// <summary>
        /// Create domain for organization
        /// </summary>
        public const string CreateMyOrgDomains = "create:my_org:domains";

        /// <summary>
        /// Read domains for organization
        /// </summary>
        public const string ReadMyOrgDomains = "read:my_org:domains";

        /// <summary>
        /// Update domain for organization
        /// </summary>
        public const string UpdateMyOrgDomains = "update:my_org:domains";

        /// <summary>
        /// Delete domain for organization
        /// </summary>
        public const string DeleteMyOrgDomains = "delete:my_org:domains";

        /// <summary>
        /// Create provisioning configuration for identity provider
        /// </summary>
        public const string CreateMyOrgIdentityProvidersProvisioning =
            "create:my_org:identity_providers_provisioning";

        /// <summary>
        /// Update provisioning configuration for identity provider
        /// </summary>
        public const string UpdateMyOrgIdentityProvidersProvisioning =
            "update:my_org:identity_providers_provisioning";

        /// <summary>
        /// Read provisioning configuration for identity provider
        /// </summary>
        public const string ReadMyOrgIdentityProvidersProvisioning =
            "read:my_org:identity_providers_provisioning";

        /// <summary>
        /// Delete provisioning configuration for identity provider
        /// </summary>
        public const string DeleteMyOrgIdentityProvidersProvisioning =
            "delete:my_org:identity_providers_provisioning";

        /// <summary>
        /// Create a provisioning SCIM token for this identity provider
        /// </summary>
        public const string CreateMyOrgIdentityProvidersScimTokens =
            "create:my_org:identity_providers_scim_tokens";

        /// <summary>
        /// List the provisioning SCIM tokens for this identity provider
        /// </summary>
        public const string ReadMyOrgIdentityProvidersScimTokens =
            "read:my_org:identity_providers_scim_tokens";

        /// <summary>
        /// Delete a provisioning SCIM configuration for an identity provider
        /// </summary>
        public const string DeleteMyOrgIdentityProvidersScimTokens =
            "delete:my_org:identity_providers_scim_tokens";

        /// <summary>
        /// List member invitations for organization
        /// </summary>
        public const string ReadMyOrgMemberInvitations = "read:my_org:member_invitations";

        /// <summary>
        /// Create member invitations for organization
        /// </summary>
        public const string CreateMyOrgMemberInvitations = "create:my_org:member_invitations";

        /// <summary>
        /// Delete member invitations for organization
        /// </summary>
        public const string DeleteMyOrgMemberInvitations = "delete:my_org:member_invitations";

        /// <summary>
        /// List members for organization
        /// </summary>
        public const string ReadMyOrgMembers = "read:my_org:members";

        /// <summary>
        /// Delete members from organization
        /// </summary>
        public const string DeleteMyOrgMembers = "delete:my_org:members";

        /// <summary>
        /// List Roles for members in organization
        /// </summary>
        public const string ReadMyOrgMemberRoles = "read:my_org:member_roles";

        /// <summary>
        /// Create Roles for members in organization
        /// </summary>
        public const string CreateMyOrgMemberRoles = "create:my_org:member_roles";

        /// <summary>
        /// Update Roles for members in organization
        /// </summary>
        public const string UpdateMyOrgMemberRoles = "update:my_org:member_roles";

        /// <summary>
        /// Delete Roles from members for organization
        /// </summary>
        public const string DeleteMyOrgMemberRoles = "delete:my_org:member_roles";

        /// <summary>
        /// Create client grants for client in organization
        /// </summary>
        public const string CreateMyOrgClientGrants = "create:my_org:client_grants";

        /// <summary>
        /// Create API clients for organization
        /// </summary>
        public const string CreateMyOrgClients = "create:my_org:clients";

        /// <summary>
        /// Read API clients for organization
        /// </summary>
        public const string ReadMyOrgClients = "read:my_org:clients";

        /// <summary>
        /// Delete API clients for organization
        /// </summary>
        public const string DeleteMyOrgClients = "delete:my_org:clients";
    }
}
