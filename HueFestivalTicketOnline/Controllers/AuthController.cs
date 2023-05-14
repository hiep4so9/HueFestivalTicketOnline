using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration/*, IUserService userService*/)
        {
            _configuration = configuration;
/*            _userService = userService;*/
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
/*            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);*/

            user.username = request.username;
            user.password = request.password;

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginDTO request)
        {
            if (user.username != request.username)
            {
                return BadRequest("User not found.");
            }

            if (user.password != request.password)
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

/*            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);*/

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.username),
/*                new Claim(ClaimTypes.Role, "Admin")
*/            };

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
    }
}
