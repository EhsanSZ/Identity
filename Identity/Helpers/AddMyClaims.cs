using Identity.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Helpers
{
    public class AddMyClaims : UserClaimsPrincipalFactory<User>
    {

        public AddMyClaims(UserManager<User> userManager
            ,IOptions<IdentityOptions> options): base(userManager , options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity =await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FullName", $"{user.FirstName} {user.LastName}"));

            return identity;
        }
    }
}
