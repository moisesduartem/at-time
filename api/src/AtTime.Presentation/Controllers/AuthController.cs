using AtTime.Core.Requests;
using AtTime.Core.Responses;
using AtTime.Infra.Repositories;
using AtTime.JwtAuthentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AtTime.Presentation.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginViewModel>> Authenticate([FromBody] LoginInputModel input)
        {
            var user = await _userRepository.GetByEmail(input.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(input.Password, user.Password))
                return NotFound(new { Message = "Invalid email and/or password" });

            var token = _tokenService.GenerateToken(user.FullName, user.RoleName);

            return Ok(new LoginViewModel(user, token));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> GetAuthenticated()
        {
            var result = await _userRepository.GetByName(User.Identity.Name);

            if (result == null)
                return NotFound(new { Message = "User not found" });

            return Ok(new UserViewModel(result));
        }
    }
}
