using Microsoft.AspNetCore.Mvc;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Repositories.IRepository;
using System.Security.Claims;
using HueFestivalTicketOnline.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;
using AutoMapper;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repo, IConfiguration configuration, IMapper mapper)
        {
            _userRepo = repo;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userRepo.GetAllUsersAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepo.GetUserAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserDTO model)
        {
            try
            {
                var newUserId = await _userRepo.AddUserAsync(model);
                var user = await _userRepo.GetUserAsync(newUserId);
                return user == null ? NotFound() : Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO model)
        {
            if (id != model.userID)
            {
                return NotFound();
            }
            await _userRepo.UpdateUserAsync(id, model);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if (!await _userRepo.CheckUserName(userName))
            {
                return NotFound("username not found");
            }
            try
            {

                var user = await _userRepo.Login(userName, password);
/*                if (userName != user.username)
                {
                    return BadRequest("User not found.");
                }*/
                
                if (password != user.password)
                {
                    return BadRequest("Wrong password.");
                }


                if (user != null)
                {
                    string token = CreateToken(user);
                    return Ok(token);
                }

                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }


        private string CreateToken(UserDTO? user)
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

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (await _userRepo.ForgotPassword(email) != -1)
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {

            if (await _userRepo.ResetPassword(request.Token, request.Password) != -1)
            {
                return Ok("Password successfully reset.");

            }
            else
            {
                return BadRequest();
            }

        }
    }
}
