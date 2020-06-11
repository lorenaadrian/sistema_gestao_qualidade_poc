using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NaoConformidadeModule.WebApi.Contracts;
using NaoConformidadeModule.WebApi.Models;
using System.Threading.Tasks;

namespace NaoConformidadeModule.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthentication _authenticate;
        private readonly IAuthorization _authorize;

        public LoginController(IAuthentication authenticate, IAuthorization authorize)
        {
            _authenticate = authenticate;
            _authorize = authorize;
        }

        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            return "Validado!";
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LoginCredencials login)
        {
            var authentication = await _authenticate.AuthenticateAsync(login);
            if (!authentication.IsValid)
            {
                return Unauthorized(authentication);
            }
            var authorization = await _authorize.AuthorizeAsync(authentication.DataEntity);
            if (!authorization.IsAuthorized)
            {
                return Forbid();
            }
            return Ok(authorization);
        }
    }
}