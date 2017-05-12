using CourseProjectSculptureWorks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseProjectSculptureWorks
{
    public class DbSeed
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public DbSeed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await _roleManager.CreateAsync(new IdentityRole("Administrator"));
            await _roleManager.CreateAsync(new IdentityRole("Guide"));

            var admin = await _userManager.FindByEmailAsync("admin@gmail.com");
            var guide = await _userManager.FindByEmailAsync("guide@gmail.com");
            await _userManager.AddToRoleAsync(admin, "Administrator");
            await _userManager.AddToRoleAsync(guide, "Guide");
        }
    }
}
