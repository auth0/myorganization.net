using System.Text.Json;
using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Core;
using Auth0.MyOrganizationApi.Organization.IdentityProviders;

namespace Auth0.MyOrganizationApi.Organization;

public partial class IdentityProvidersClient : IIdentityProvidersClient
{
    private readonly RawClient _client;

    internal IdentityProvidersClient(RawClient client)
    {
        _client = client;
        Domains = new Auth0.MyOrganizationApi.Organization.IdentityProviders.DomainsClient(_client);
        Provisioning = new ProvisioningClient(_client);
    }

    public Auth0.MyOrganizationApi.Organization.IdentityProviders.IDomainsClient Domains { get; }

    public IProvisioningClient Provisioning { get; }

    private async Task<WithRawResponse<ListIdentityProvidersResponseContent>> ListAsyncCore(
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
                    Path = "identity-providers",
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
                var responseData = JsonUtils.Deserialize<ListIdentityProvidersResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<ListIdentityProvidersResponseContent>()
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

    private async Task<WithRawResponse<IdpKnownResponse>> CreateAsyncCore(
        IdpKnownRequest request,
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
                    Path = "identity-providers",
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IdpKnownResponse>(responseBody)!;
                return new WithRawResponse<IdpKnownResponse>()
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
                    case 409:
                        throw new ConflictError(
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

    private async Task<WithRawResponse<IdpKnownResponse>> GetAsyncCore(
        string idpId,
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
                        "identity-providers/{0}",
                        ValueConvert.ToPathParameterString(idpId)
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
                var responseData = JsonUtils.Deserialize<IdpKnownResponse>(responseBody)!;
                return new WithRawResponse<IdpKnownResponse>()
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

    private async Task<WithRawResponse<IdpUpdateKnownResponse>> UpdateAsyncCore(
        string idpId,
        IdpUpdateKnownRequest request,
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
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format(
                        "identity-providers/{0}",
                        ValueConvert.ToPathParameterString(idpId)
                    ),
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IdpUpdateKnownResponse>(responseBody)!;
                return new WithRawResponse<IdpUpdateKnownResponse>()
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

    private async Task<WithRawResponse<IdpKnownResponse>> UpdateAttributesAsyncCore(
        string idpId,
        Dictionary<string, object?> request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "identity-providers/{0}/update-attributes",
                        ValueConvert.ToPathParameterString(idpId)
                    ),
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IdpKnownResponse>(responseBody)!;
                return new WithRawResponse<IdpKnownResponse>()
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
    /// List the identity providers associated with this organization.
    /// </summary>
    /// <example><code>
    /// await client.Organization.IdentityProviders.ListAsync();
    /// </code></example>
    public WithRawResponseTask<ListIdentityProvidersResponseContent> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListIdentityProvidersResponseContent>(
            ListAsyncCore(options, cancellationToken)
        );
    }

    /// <summary>
    /// Create an identity provider associated with this organization.
    /// </summary>
    /// <example><code>
    /// await client.Organization.IdentityProviders.CreateAsync(
    ///     new IdpOidcRequest
    ///     {
    ///         Name = "oidcIdp",
    ///         Strategy = IdpOidcRequestStrategy.Oidc,
    ///         Domains = new List&lt;string&gt;() { "mydomain.com" },
    ///         DisplayName = "OIDC IdP",
    ///         ShowAsButton = true,
    ///         AssignMembershipOnLogin = false,
    ///         IsEnabled = true,
    ///         Options = new IdpOidcOptionsRequest
    ///         {
    ///             Type = IdpOidcOptionsTypeEnum.FrontChannel,
    ///             ClientId = "a8f3b2e7-5d1c-4f9a-8b0d-2e1c3a5b6f7d",
    ///             ClientSecret = "KzQp2sVxR8nTgMjFhYcEWuLoIbDvUoC6A9B1zX7yWqFjHkGrP5sQdLmNp",
    ///             DiscoveryUrl = "https://{yourDomain}/.well-known/openid-configuration",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<IdpKnownResponse> CreateAsync(
        IdpKnownRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IdpKnownResponse>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve the details for one particular identity-provider.
    /// </summary>
    /// <example><code>
    /// await client.Organization.IdentityProviders.GetAsync("idp_id");
    /// </code></example>
    public WithRawResponseTask<IdpKnownResponse> GetAsync(
        string idpId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IdpKnownResponse>(
            GetAsyncCore(idpId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete an identity provider from this organization.
    /// </summary>
    /// <example><code>
    /// await client.Organization.IdentityProviders.DeleteAsync("idp_id");
    /// </code></example>
    public async Task DeleteAsync(
        string idpId,
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "identity-providers/{0}",
                        ValueConvert.ToPathParameterString(idpId)
                    ),
                    Headers = _headers,
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

    /// <summary>
    /// Update an identity provider associated with this organization.
    /// </summary>
    /// <example><code>
    /// await client.Organization.IdentityProviders.UpdateAsync(
    ///     "idp_id",
    ///     new IdpOidcUpdateRequest
    ///     {
    ///         DisplayName = "OIDC IdP",
    ///         ShowAsButton = true,
    ///         AssignMembershipOnLogin = false,
    ///         IsEnabled = true,
    ///         Options = new IdpOidcOptionsRequest
    ///         {
    ///             Type = IdpOidcOptionsTypeEnum.FrontChannel,
    ///             ClientId = "a8f3b2e7-5d1c-4f9a-8b0d-2e1c3a5b6f7d",
    ///             ClientSecret = "KzQp2sVxR8nTgMjFhYcEWuLoIbDvUoC6A9B1zX7yWqFjHkGrP5sQdLmNp",
    ///             DiscoveryUrl = "https://{yourDomain}/.well-known/openid-configuration",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<IdpUpdateKnownResponse> UpdateAsync(
        string idpId,
        IdpUpdateKnownRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IdpUpdateKnownResponse>(
            UpdateAsyncCore(idpId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Triggers a refresh of attribute mappings on the identity provider by overriding it with the admin defined defaults. The endpoint doesn't accept any body parameters.
    /// </summary>
    /// <example><code>
    /// await client.Organization.IdentityProviders.UpdateAttributesAsync(
    ///     "idp_id",
    ///     new Dictionary&lt;string, object?&gt;() { { "key", "value" } }
    /// );
    /// </code></example>
    public WithRawResponseTask<IdpKnownResponse> UpdateAttributesAsync(
        string idpId,
        Dictionary<string, object?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IdpKnownResponse>(
            UpdateAttributesAsyncCore(idpId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete underlying identity provider from this organization.
    /// </summary>
    /// <example><code>
    /// await client.Organization.IdentityProviders.DetachAsync("idp_id");
    /// </code></example>
    public async Task DetachAsync(
        string idpId,
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
                        "identity-providers/{0}/detach",
                        ValueConvert.ToPathParameterString(idpId)
                    ),
                    Headers = _headers,
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
