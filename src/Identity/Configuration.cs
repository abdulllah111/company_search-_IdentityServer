using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Identity
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
           new List<ApiScope>{
                new ApiScope("CompanySearchWebAPI", "Web API")
           };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>{
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>{
                new ApiResource("CompanySearchWebAPI", "Web API", new [] {JwtClaimTypes.Name, JwtClaimTypes.BirthDate, JwtClaimTypes.Gender}){
                    Scopes = {"CompanySearchWebAPI"}
                }
            };
        public static IEnumerable<Client> Clients =>
            new List<Client>{
                new Client{
                    ClientId = "company-search-web-api",
                    ClientName = "MyWebAPI",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris = {
                        "http://.../signin-oidc"
                    },
                    AllowedCorsOrigins = {
                        "http://..."
                    },
                    PostLogoutRedirectUris = {
                        "http://.../signout-oidc"
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "CompanySearchWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}