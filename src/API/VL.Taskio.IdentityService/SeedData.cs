using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using VL.Taskio.IdentityService.Data;
using VL.Taskio.IdentityService.Models;

namespace VL.Taskio.IdentityService;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        context.Database.Migrate();

        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var luis = userMgr.FindByNameAsync("luis").Result;

        if (luis is null)
        {
            luis = new ApplicationUser
            {
                UserName = "luis",
                Email = "luis@email.com",
                EmailConfirmed = true,
            };
            var result = userMgr.CreateAsync(luis, "Pa$$w0rd").Result;
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            result = userMgr.AddClaimsAsync(luis, new Claim[]{
                new(JwtClaimTypes.Name, "Luis Inacio"),
                new(JwtClaimTypes.GivenName, "Luis"),
                new(JwtClaimTypes.FamilyName, "Inacio"),
                new(JwtClaimTypes.WebSite, "http://luisinacio.com"),
            }).Result;

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            Log.Debug("Luis created");
        }
        else
        {
            Log.Debug("Luis already exists");
        }
    }
}
