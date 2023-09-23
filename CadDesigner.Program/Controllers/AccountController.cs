using CadDesigner.Aplication.DtoModels;
using CadDesigner.Aplication.Services;
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
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
    }
}