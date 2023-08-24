using System.Security.Claims;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using VL.Taskio.IdentityService.Models;

namespace VL.Taskio.IdentityService.Services;

public class CustomProfileService : IProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CustomProfileService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var user = await _userManager.GetUserAsync(context.Subject);

        if (user is null) return;

        var existingClaims = await _userManager.GetClaimsAsync(user);

        var claims = new List<Claim>
        {
            new("username", user.UserName ?? "Guest")
        };

        context.IssuedClaims.AddRange(claims);

        var nameClaim = existingClaims.FirstOrDefault(x => x.Type == JwtClaimTypes.Name);

        if (nameClaim is not null)
        {
            context.IssuedClaims.Add(nameClaim);
        }
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        return Task.CompletedTask;
    }
}
