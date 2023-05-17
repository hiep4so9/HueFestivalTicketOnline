using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository repo)
        {
            _userRepo = repo;
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

        /*        [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteUser([FromRoute] int id)
                {
                    await _userRepo.DeleteUserAsync(id);
                    return Ok();
                }*/

/*        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (!await _userRepo.CheckUserName(username))
            {
                return NotFound("username not found");
            }
            var user = await _userRepo.GetUserByUsernamePasswordAsync(username, password);
            if (user != null)
            {
                string token = CreateToken(user);

                return Ok(new ApiResponse
                {
                    Message = "Login success",
                    Data = token,
                    Success = true,

                });
            }
            else
            {
                return NotFound("password wrong");
            }

        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>{
            new Claim(ClaimTypes.Name, user.username)
        };
            var secretKey = "g4gvaPfOulR6bdI6KNL5ikcqbGc7Ouq4";

            if (secretKey != null)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: creds
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return jwt;
            }
            return null;*/
/*
        }*/
    }
}
