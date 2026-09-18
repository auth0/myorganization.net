using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;

namespace Auth0.MyOrganizationApi.Organization.Invitations;

public partial class RolesClient : IRolesClient
{
    private readonly RawClient _client;

    internal RolesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<GetMemberInvitationRolesResponseContent>> ListAsyncCore(
        string invitationId,
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
                    Path = string.Format(
                        "member-invitations/{0}/roles",
                        ValueConvert.ToPathParameterString(invitationId)
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
                var responseData = JsonUtils.Deserialize<GetMemberInvitationRolesResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetMemberInvitationRolesResponseContent>()
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
    /// Retrieve the roles assigned to a member invitation specified by ID for this Organization.
    /// </summary>
    /// <example><code>
    /// await client.Organization.Invitations.Roles.ListAsync("invitation_id");
    /// </code></example>
    public WithRawResponseTask<GetMemberInvitationRolesResponseContent> ListAsync(
        string invitationId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetMemberInvitationRolesResponseContent>(
            ListAsyncCore(invitationId, options, cancellationToken)
        );
    }
}
