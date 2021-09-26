using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raymon.Common.Dtos;
using Raymon.Services.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raymon.LoginApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
              var result=  await _loginService.UserLogin(loginDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("خطا در ورود کاربر");

            }

        }
    }
}
