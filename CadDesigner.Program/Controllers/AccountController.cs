using CadDesigner.Aplication.DtoModels;
using CadDesigner.Aplication.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CadDesigner.Program.Controllers
{
    [Route("api/accaunt")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)         
        {
            _accountService = accountService;
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            await _accountService.RegisterUser(dto);
            return Ok();
        }



        [HttpGet("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto dto)
        {
            string token = await _accountService.GenerateJwt(dto);

            return Ok(token);
        }
    }
}