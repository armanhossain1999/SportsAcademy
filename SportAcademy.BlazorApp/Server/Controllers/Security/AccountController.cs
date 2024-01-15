using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SportAcademy.BlazorApp.Server.DataApi.ViewModels.Identity;
using SportAcademy.BlazorApp.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SportAcademy.BlazorApp.Server.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration config;
        public readonly SportsEdgeDbContext db;
        public AccountController(UserManager<IdentityUser> userManager, IConfiguration config, SportsEdgeDbContext db)
        {
            this.userManager = userManager;
            this.config = config;
            this.db = db;
        }
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Staff");
            }
            return Ok(new { Username = user.UserName });
        }
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var roles = await userManager.GetRolesAsync(user);
                var signingKey =
                  Encoding.UTF8.GetBytes(config["Jwt:SigningKey"] ?? "IsDB-BISEW ESAD-54");
                var expiryDuration = int.Parse(config["Jwt:ExpiryInMinutes"] ?? "30");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = null,              // Not required as no third-party is involved
                    Audience = null,            // Not required as no third-party is involved
                    IssuedAt = DateTime.UtcNow,
                    NotBefore = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                    Subject = new ClaimsIdentity(
                        new List<Claim> {
                        new Claim("username",user.UserName ?? ""),
                        new Claim("roles", string.Join(",", string.Join(",", roles))),
                        new Claim("expires", DateTime.UtcNow.AddMinutes(expiryDuration).ToString("yyyy-MM-ddTHH:mm:ss"))
                        }
                    ),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                var token = jwtTokenHandler.WriteToken(jwtToken);
                return Ok(
                 new
                 {
                     token

                 });
            }
            return BadRequest();
        }
    }
}
