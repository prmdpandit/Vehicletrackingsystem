using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                   new Client
                   {
                        ClientId = "deviceClient",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha512())
                        },
                        AllowedScopes = { "vehicleTrackingSystemAPI" }
                   },
                   new Client
                   {
                       ClientId = "device_client",
                       ClientName = "device App",
                       AllowedGrantTypes = GrantTypes.Hybrid,
                       RequirePkce = false,
                       AllowRememberConsent = false,
                       RedirectUris = new List<string>()
                       {
                           "https://localhost:5002/signin-oidc"
                       },
                       PostLogoutRedirectUris = new List<string>()
                       {
                           "https://localhost:5002/signout-callback-oidc"
                       },
                       ClientSecrets = new List<Secret>
                       {
                           new Secret("secret".Sha512())
                       },
                       AllowedScopes = new List<string>
                       {
                           IdentityServerConstants.StandardScopes.OpenId,
                           IdentityServerConstants.StandardScopes.Profile,
                           IdentityServerConstants.StandardScopes.Address,
                           IdentityServerConstants.StandardScopes.Email,                           
                           "vehicleTrackingSystemAPI",
                           "roles"
                       }
                   }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
               new ApiScope("vehicleTrackingSystemAPI", "vehicleTrackingSystem API")
           };

        public static IEnumerable<ApiResource> ApiResources =>
          new ApiResource[]
          {
               new ApiResource("vehicleTrackingSystemAPI", "vehicleTrackingSystem API")
          };

        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResources.Address(),
              new IdentityResources.Email(),
              new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })
          };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "test",
                    Password = "test123",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "testname"),
                        new Claim(JwtClaimTypes.FamilyName, "testfamily")
                    }
                }
            };
    }
}
