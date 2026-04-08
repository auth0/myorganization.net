namespace Auth0.MyOrganizationApi.Core;

public interface IStringEnum : IEquatable<string>
{
    public string Value { get; }
}
