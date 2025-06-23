using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Authorization;

public class RestaurantsUserClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
{
    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var id = await GenerateClaimsAsync(user);
        if (user.Nationality != null)
        {
            id.AddClaim(new("Nationality", user.Nationality));
        }
        if (user.DateOfBird != null)
        {
            id.AddClaim(new("DateOfBirth", user.DateOfBird.Value.ToString("yyyy-MM-dd")));
        }
        return new ClaimsPrincipal(id);
    }
}
