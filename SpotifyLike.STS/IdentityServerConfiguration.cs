using IdentityServer4;
using IdentityServer4.Models;

namespace SpotifyLike.STS
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResource()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>()
            {
                new ApiResource("spotifyLike-api", "SpotifyLike", new string[] { "spotifylike-user" })
                {
                    ApiSecrets =
                    {
                        new Secret("SpolitifyLikeSecret".Sha256())
                    },
                    Scopes =
                    {
                        "SpotifyLikeScope"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope()
                {
                    Name = "SpotifyLikeScope",
                    DisplayName = "SpotifyLike API",
                    UserClaims = { "spotifylike-user" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "client-angular-spotify",
                    ClientName = "Acesso do front as APIS",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("SpotifyLikeSecret".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SpotifyLikeScope"
                    }
                }
            };
        }
    }
}
