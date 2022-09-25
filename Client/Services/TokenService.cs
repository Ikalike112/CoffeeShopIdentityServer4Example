
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Client.Services
{
    public class TokenService : ITokenService
    {
        public readonly IOptions<IdentityServerSettings> IdentityServerSettings;
        public readonly DiscoveryDocumentResponse discoveryDocument;
        private readonly HttpClient httpClient;

        public TokenService(IOptions<IdentityServerSettings>
            identityServerSettings)
        {
            this.IdentityServerSettings= identityServerSettings;
            httpClient = new HttpClient();
            discoveryDocument = httpClient.GetDiscoveryDocumentAsync
                (this.IdentityServerSettings.Value.DiscoveryUrl).Result;
            if (discoveryDocument.IsError)
            {
                throw new Exception("Unable to get discovery document", discoveryDocument.Exception);
            }
        }

        public async Task<TokenResponse> GetToken(string scope)
        {
            var tokenRespone = await httpClient.RequestClientCredentialsTokenAsync(new
                ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = IdentityServerSettings.Value.ClientName,
                ClientSecret= IdentityServerSettings.Value.ClientPassword,
                Scope = scope
            });
            if (tokenRespone.IsError)
            {
                throw new Exception("Unable to get token", tokenRespone.Exception);
            }
            return tokenRespone;
        }
    }
}
