using System.Text.Json;
using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi.Organization.Configuration;

public partial class IdentityProvidersClient : IIdentityProvidersClient
{
    private readonly RawClient _client;

    internal IdentityProvidersClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<IdentityProvidersConfig>> GetAsyncCore(
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
                    Method = HttpMethod.Get,
                    Path = "config/identity-providers",
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IdentityProvidersConfig>(responseBody)!;
                return new WithRawResponse<IdentityProvidersConfig>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new MyOrganizationApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    null,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
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

    /// <summary>
    /// Retrieve the connection profile for the application. This will give the components all of the information they will need to be successful. The SDK provider for the components should manage fetching and caching this information for all components.
    /// </summary>
    /// <example><code>
    /// await client.Organization.Configuration.IdentityProviders.GetAsync();
    /// </code></example>
    public WithRawResponseTask<IdentityProvidersConfig> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IdentityProvidersConfig>(
            GetAsyncCore(options, cancellationToken)
        );
    }
}
