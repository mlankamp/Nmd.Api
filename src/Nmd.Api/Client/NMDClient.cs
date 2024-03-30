using System.Net.Http.Headers;
using System.Text;

using Newtonsoft.Json;

using NMD.Api.Options;

namespace NMD.Api;
public partial class NMDClient
{
    private readonly NMDConfiguration configuration;
    internal AuthToken? token = null;

    public NMDClient(HttpClient httpClient, NMDConfiguration configuration) : this(httpClient)
    {
        ArgumentNullException.ThrowIfNull(configuration.ClientId, nameof(configuration.ClientId));
        ArgumentNullException.ThrowIfNull(configuration.ClientSecret, nameof(configuration.ClientSecret));

        this.configuration = configuration;
        httpClient.BaseAddress = new Uri(configuration.BaseUrl);
    }

    public async Task PrepareRequestAsync(HttpClient client_, HttpRequestMessage request_, StringBuilder urlBuilder_, CancellationToken cancellationToken)
    {
        var token = await this.GetTokenAsync();
        request_.Headers.Authorization = new AuthenticationHeaderValue(token.Scheme, token.AccessToken);
    }

    public Task PrepareRequestAsync(HttpClient client_, HttpRequestMessage request_, string url_, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task ProcessResponseAsync(HttpClient client_, HttpResponseMessage response_, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    internal async Task<AuthToken> GetTokenAsync()
    {
        if (this.token != null && this.token.ValidUntil > DateTimeOffset.UtcNow)
        {
            return this.token;
        }

        var formData = new List<KeyValuePair<string, string>>
            {
                new("grant_type", configuration.GrantType),
                new("scope", configuration.Scope),
                new("client_id", configuration.ClientId),
                new("client_secret", configuration.ClientSecret),
            };
        var authContent = new FormUrlEncodedContent(formData);

        var response = await this._httpClient.PostAsync(this.configuration.AuthUrl, authContent);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var token = JsonConvert.DeserializeObject<AuthToken>(json!);
        if (token == null || string.IsNullOrEmpty(token?.AccessToken))
        {
            throw new Exception("Failed to get access token");
        }

        token!.ValidUntil = DateTimeOffset.UtcNow.AddSeconds(token.ExpiresIn - 600);
        this.token =  token;

        return this.token;
    }

    internal record AuthToken
    {
        [JsonProperty("access_token")]
        public string? AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string? Scheme { get; set; }

        [JsonIgnore]
        public DateTimeOffset ValidUntil { get; set; }
    }
}
