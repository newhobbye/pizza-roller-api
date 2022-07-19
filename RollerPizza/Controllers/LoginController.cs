using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Security.Claims;

namespace RollerPizza.Controllers
{
    [ApiController]
    [Route("api/pizza/login")]
    public class LoginController : Controller
    {
        IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("userAndPassword")]
        public async Task<IActionResult> LoginRollerPizzaClient(string nickName, string password)
        {

            if (User.Identity.IsAuthenticated)
            {
                return Json(new { Mensagem = "Usuário já está logado!" });
            }

            MySqlConnection mySqlConnection = new("server = localhost; database = PizzaRoller; user = Robson; password = R55108105");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM client  WHERE NickName = '{nickName}' AND Password = '{password}'";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

                if(await reader.ReadAsync())
                {
                    string userCPFId = reader.GetString(0);
                    string name = reader.GetString(1);
                    string email = reader.GetString(4);

                    List<Claim> securityAccess = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, userCPFId),
                        new Claim(ClaimTypes.Name, name),
                        new Claim(ClaimTypes.Email, email),
                    };

                    var identity = new ClaimsIdentity(securityAccess, "Identity.Login");
                    var userPrincipal = new ClaimsPrincipal(new[] { identity });

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
