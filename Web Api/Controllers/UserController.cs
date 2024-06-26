using BusinessAccessLayer.DTOs;
using BusinessAccessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult<UserDTO>> SignUp(UserDTO userDTO)
        {
            var user = await _userService.SignUp(userDTO);
            return Ok(user);
        }

        [HttpPost("log-in")]
        public async Task<ActionResult<UserDTO>> LogIn(UserDTO userDTO)
        {
            try
            {
                var user = await _userService.LogIn(userDTO);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
