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
    public class StudentAuthController : ControllerBase
    {
        public static StudentRegister student = new StudentRegister();
        private readonly IConfiguration _configuration;

        public StudentAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<StudentRegister>> Register(StudentDto request)
        {
            CreatePasswordHash(request.student_password, out byte[] student_passwordHash, out byte[] student_passwordSalt);

            student.student_username = request.student_username;
            student.student_passwordHash = student_passwordHash;
            student.student_passwordSalt = student_passwordSalt;

            return Ok(student);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(StudentDto request)
        {
            if (student.student_username != request.student_username)
            {
                return BadRequest("Username not found.");
            }

            if (!VerifyPasswordHash(request.student_password, student.student_passwordHash, student.student_passwordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(student);
            return Ok(token);
        }

        private string CreateToken(StudentRegister student)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, student.student_username),
                new Claim(ClaimTypes.Role, "Student")
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

        private void CreatePasswordHash(string student_password, out byte[] student_passwordHash, out byte[] student_passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                student_passwordSalt = hmac.Key;
                student_passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(student_password));
            }
        }

        private bool VerifyPasswordHash(string student_password, byte[] student_passwordHash, byte[] student_passwordSalt)
        {
            using (var hmac = new HMACSHA512(student_passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(student_password));
                return computedHash.SequenceEqual(student_passwordHash);
            }
        }
    }
}
