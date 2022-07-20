using MySql.Data.MySqlClient;
using RollerPizza.Data;
using System.Security.Claims;

namespace RollerPizza.Service
{
    public class LoginService
    {
        private IConfiguration _configuration;

        public LoginService(IConfiguration configuration, DBContext data)
        {
            //data.Clients. Trabalhar com clientDao ao inves do Mysqlconnection
            _configuration = configuration;
        }

        public async Task<ClaimsPrincipal> CreateLogin(string nickName, string password)
        {
            
            MySqlConnection mySqlConnection = new(_configuration.GetConnectionString("ContextConnection"));
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            //string query = _configuration["QueryLogin"];
            mySqlCommand.CommandText = $"SELECT * FROM client  WHERE NickName = '{nickName}' AND Password = '{password}'";

            
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            if (await reader.ReadAsync())
            {
                string userCPFId = reader.GetString(0);
                string name = reader.GetString(1);
                string email = reader.GetString(4);

                List<Claim> securityAccess = new List<Claim> //claim representa uma declaração
                    {
                        new Claim(ClaimTypes.NameIdentifier, userCPFId),
                        new Claim(ClaimTypes.Name, name),
                        new Claim(ClaimTypes.Email, email),
                    };

                var identity = new ClaimsIdentity(securityAccess, "Identity.Login");
                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                
                return userPrincipal;
            }
            return null;
        }
    }
}
