// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "Hosaplya 16 main",
                    locality = "Bengaluru",
                    postal_code = 560068,
                    country = "India"
                };
                
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "1234567",
                        Username = "prmdpandit",
                        Password = "p1",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Pramod Pandit"),
                            new Claim(JwtClaimTypes.GivenName, "Pramod"),
                            new Claim(JwtClaimTypes.FamilyName, "Pandit"),
                            new Claim(JwtClaimTypes.Email, "prmdpandit@gmail.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://csdotnet.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "user")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "12345678",
                        Username = "cs",
                        Password = "c1",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Cs dotnet"),
                            new Claim(JwtClaimTypes.GivenName, "csdotnet"),
                            new Claim(JwtClaimTypes.FamilyName, "pandit"),
                            new Claim(JwtClaimTypes.Email, "msdotnetcs@gmail.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://dotnetcs.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),                            
                            new Claim(JwtClaimTypes.Role, "admin")
                        }
                    }
                };
            }
        }
    }
}