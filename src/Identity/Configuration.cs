using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityModel;

namespace Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("CompanySearchWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("CompanySearchWebAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = {"CompanySearchWebAPI"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "company-search-web-app",
                    ClientName = "CompanySearch Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "https://localhost:7285/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://localhost:7285"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7285/signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "CompanySearchWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
