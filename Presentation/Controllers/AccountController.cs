using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects;
using Shared.ErrorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IServiceManager _serviceManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IServiceManager serviceManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _serviceManager = serviceManager;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return Unauthorized(new ErrorToReturn() { StatusCode = 401, ErrorMessage = "UnAuthorized, please login and try again" });
            }

            var Result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!Result.Succeeded)
            {
                return Unauthorized(new ErrorToReturn() { StatusCode = 401, ErrorMessage = "UnAuthorized, please login and try again" });
            }

            return Ok(new UserDto()
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await _serviceManager.AuthService.CreateTokenAsync(user, _userManager)
            });
        }
    }
}
