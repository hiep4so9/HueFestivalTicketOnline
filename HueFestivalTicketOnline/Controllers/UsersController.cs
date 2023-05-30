using Microsoft.AspNetCore.Mvc;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Repositories.IRepository;
using AutoMapper;
using HueFestivalTicketOnline.Prototypes;
using HueOnlineTicketFestival.Prototypes;
using HueFestivalTicketOnline.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserRepository repo, IConfiguration configuration, IMapper mapper, ILogger<UsersController> logger)
        {
            _userRepo = repo;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers(int page = 1, int pageSize = 10)
        {
            try
            {
                var allUsers = await _userRepo.GetAllUsersAsync();
                var paginatedUsers = Pagination.Paginate(allUsers, page, pageSize);

                var totalUsers = allUsers.Count;
                var totalPages = Pagination.CalculateTotalPages(totalUsers, pageSize);

                var paginationInfo = new
                {
                    TotalUsers = totalUsers,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return Ok(new { Users = paginatedUsers, Pagination = paginationInfo });
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("{id}"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepo.GetUserAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string email, string username, string password)
        {
            _logger.LogInformation("Creating a new User");

            try
            {
                var newUser = new UserDTO
                {
                    Email = email,
                    username = username,
                    password = password,
                    VerificationToken = jwtHandler.CreateRandomToken()
                };


                if (await _userRepo.AddUserAsync(newUser) != -1)
                {
                    return Ok(new ApiResponse
                    {
                        Success = true,
                        Message = "Register success",
                        Data = CreatedAtAction(nameof(GetUserById), new { id = newUser.userID }, newUser)
                    });
                }
                else
                {
                    return BadRequest(new ApiResponse
                    {
                        Success = false,
                        Message = "Register fail:The user already exists  ",
                        Data = null,
                    });
                }
            }
            catch (System.Exception e)
            {

                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Register fail: " + e.GetBaseException(),
                    Data = null,
                });
            }

        }


        [HttpPut("{id}"), Authorize(Roles = "Admin")]
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
            GenerateToken tokenGenerator = new GenerateToken(_configuration);

            if (!await _userRepo.CheckUserName(userName))
            {
                return NotFound("username not found");
            }
            try
            {

                var user = await _userRepo.Login(userName, password);


                var passwordHash = HashMD5.GetMD5Hash(password);
                if (passwordHash != user.password)
                {
                    return BadRequest("Wrong password.");
                }

                if (user.VerifyAt == null)
                {
                    return BadRequest("Not verify");
                }

                if (user != null)
                {
                    string token = tokenGenerator.CreateToken(user);

                    var refreshToken = GenerateRefreshToken.CreateRefreshToken();
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = refreshToken.Expires
                    };
                    Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
                    /*                    SetRefreshToken(refreshToken,user);*/
                    await _userRepo.SetRefreshToken(user.userID, refreshToken);

                    return Ok(token);
                }

                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("verify")]
        public async Task<IActionResult> Verify(string token)
        {

            if (await _userRepo.VerifyEmail(token) != -1)
            {
                return Ok("User verify");
            }
            else
            {
                return BadRequest("Invalid token");
            }

        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            GenerateToken tokenGenerator = new GenerateToken(_configuration);
            var refreshToken = Request.Cookies["refreshToken"];

            var user = await _userRepo.GetUserByRefreshToken(refreshToken);
            if (user == null)
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = tokenGenerator.CreateToken(user);
            var newRefreshToken = GenerateRefreshToken.CreateRefreshToken();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);
            await _userRepo.SetRefreshToken(user.userID, newRefreshToken);

            return Ok(token);
        }


        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (await _userRepo.ForgotPassword(email) != -1)
            {
                return Ok("success");

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
