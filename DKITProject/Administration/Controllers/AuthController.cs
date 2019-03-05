using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Web;
using System.Text;
using DKITProject.DAL;
using DKITProject.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DKITProject.Administration.Controllers
{
    public class AuthController : Controller
    {
        private ApplicationContext context;

        public AuthController(ApplicationContext _context)
        {
            context = _context;
        }

        [HttpPost("api/authorization")]
        public IActionResult getToken([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identity = GetIdentity(user.Login, user.Password);
            if (identity == null)
                return BadRequest("Invalid login or password");

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                user_name = identity.Name,
                role = identity.RoleClaimType
            };

            return Ok(response);
        }

        private ClaimsIdentity GetIdentity(string login, string password)
        {
            var users = context.Users.Include(u => u.Role);
            User user = users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if(user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.FullName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, user.Role.Name);
            return claimsIdentity;
        }

        [Authorize]
        [HttpGet("api/checkaccess")]
        public IActionResult CheckAccess()
        {
            return Ok(true);
        }
    }
}
