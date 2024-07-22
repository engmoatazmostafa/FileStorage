using Microsoft.AspNetCore.Mvc;
using FileStorage.Models;
using FileStorage.Services;
using System.Threading.Tasks;

namespace FileStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _userService.RegisterAsync(model);
            if (!result)
            {
                return BadRequest("User registration failed.");
            }

            return Ok("User registered successfully.");
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(LoginModel model)
        {
            _logger.LogInformation("authenticate beginning");
            var token = await _userService.AuthenticateAsync(model);
            if (token == null)
            {
                _logger.LogError("authenticate error");
                return Unauthorized("Authentication failed.");
            }
            _logger.LogInformation("authenticate success");

            return Ok(new { Token = token });
        }

    }
}
