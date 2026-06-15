using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;

namespace Auth0.MyOrganizationApi.Organization;

public partial class MembershipsClient : IMembershipsClient
{
    private readonly RawClient _client;

    internal MembershipsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Remove one member from this Organization. The underlying user account is not deleted.
    /// </summary>
    /// <example><code>
    /// await client.Organization.Memberships.DeleteMembershipsAsync(
    ///     new DeleteOrganizationMembershipsRequestParameters
    ///     {
    ///         Members = new List&lt;string&gt;() { "auth0|1234567890" },
    ///     }
    /// );
    /// </code></example>
    public async Task DeleteMembershipsAsync(
        DeleteOrganizationMembershipsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new Auth0.MyOrganizationApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "delete-memberships",
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<ErrorResponseContent>(responseBody)
                        );
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponseContent>(responseBody)
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<ErrorResponseContent>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<ErrorResponseContent>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new MyOrganizationApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
