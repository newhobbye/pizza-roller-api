using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RollerPizza.Service;

namespace RollerPizza.Controllers
{
    [ApiController]
    [Route("api/pizza/login")]
    public class LoginController : Controller
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("userAndPassword")]
        public async Task<IActionResult> LoginRollerPizzaClient(string nickName, string password)
        {
            
            if (User.Identity.IsAuthenticated)
            {
                return Json(new { Mensagem = "Usuário já está logado!" });
            }

            

            var userPrincipal = await _loginService.CreateLogin(nickName, password);

            if (userPrincipal != null)
            {
                await HttpContext.SignInAsync(userPrincipal,
                    new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1),
                    }
                    );

                return Json(new { Mensagem = "Usuário logado com sucesso!" });
            }


            return Json(new { Mensagem = "Usuário não encontrado! Verifique a o nick ou a senha!" });
        }



        [HttpGet("logout")]
        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }

            return RedirectToAction("LoginRollerPizzaClient", "Login");
        }

    }



}
