using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raymon.Common.Dtos;
using Raymon.Services.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raymon.RegisterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RegisterController : ControllerBase
    {


        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                await _registerService.CreateUser(createUserDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("خطا در ثبت کاربر");

            }
        
        }
    }
}
