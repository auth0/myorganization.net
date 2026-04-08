using System.Text.Json;
using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;

namespace Auth0.MyOrganizationApi.Organization.Domains;

public partial class VerifyClient : IVerifyClient
{
    private readonly RawClient _client;

    internal VerifyClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<OrgDomain>> CreateAsyncCore(
        string domainId,
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
                    Path = string.Format(
                        "domains/{0}/verify",
                        ValueConvert.ToPathParameterString(domainId)
                    ),
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
                var responseData = JsonUtils.Deserialize<OrgDomain>(responseBody)!;
                return new WithRawResponse<OrgDomain>()
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

    /// <summary>
    /// Get a verification text and start the domain verification process for a particular domain.
    /// </summary>
    /// <example><code>
    /// await client.Organization.Domains.Verify.CreateAsync("domain_id");
    /// </code></example>
    public WithRawResponseTask<OrgDomain> CreateAsync(
        string domainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<OrgDomain>(
            CreateAsyncCore(domainId, options, cancellationToken)
        );
    }
}
