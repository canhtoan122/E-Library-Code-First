using E_Library_04.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsAuthController : ControllerBase
    {
        public static AdministratorsRegister administrators = new AdministratorsRegister();
        private readonly IConfiguration _configuration;

        public AdministratorsAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AdministratorsRegister>> Register(AdministratorsDto request)
        {
            CreatePasswordHash(request.administrator_password, out byte[] administrator_passwordHash, out byte[] administrator_passwordSalt);

            administrators.administrator_username = request.administrator_username;
            administrators.administrator_passwordHash = administrator_passwordHash;
            administrators.administrator_passwordSalt = administrator_passwordSalt;

            return Ok(administrators);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AdministratorsDto request)
        {
            if (administrators.administrator_username != request.administrator_username)
            {
                return BadRequest("Username not found.");
            }

            if (!VerifyPasswordHash(request.administrator_password, administrators.administrator_passwordHash, administrators.administrator_passwordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(administrators);
            return Ok(token);
        }

        private string CreateToken(AdministratorsRegister administrators)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, administrators.administrator_username),
                new Claim(ClaimTypes.Role, "Administrators")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string administrator_password, out byte[] administrator_passwordHash, out byte[] administrator_passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                administrator_passwordSalt = hmac.Key;
                administrator_passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(administrator_password));
            }
        }

        private bool VerifyPasswordHash(string administrator_password, byte[] administrator_passwordHash, byte[] administrator_passwordSalt)
        {
            using (var hmac = new HMACSHA512(administrator_passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(administrator_password));
                return computedHash.SequenceEqual(administrator_passwordHash);
            }
        }
    }
}
