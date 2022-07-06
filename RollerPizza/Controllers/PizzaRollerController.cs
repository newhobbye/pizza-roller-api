using Microsoft.AspNetCore.Mvc;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;
using RollerPizza.Service.Use_Case;

namespace RollerPizza.Controllers
{
    [ApiController]
    [Route("api/pizza/admin")]
    public class PizzaRollerController : Controller
    {

        private PizzaHandler _pizzaHandler;
        private DrinkHandler _drinkHandler;
        private ClientHandler _clientHandler;
        private AdressHandler _adressHandler;

        public PizzaRollerController(PizzaHandler pizzaHandler, DrinkHandler drinkHandler, ClientHandler clientHandler
            , AdressHandler adressHandler)
        {
            _pizzaHandler = pizzaHandler;
            _drinkHandler = drinkHandler;
            _clientHandler = clientHandler;
            _adressHandler = adressHandler;
        }

        #region "GET"

        [HttpGet("getPizza")]
        public IEnumerable<PizzaViewModel> MenuPizzas()
        {
            return _pizzaHandler.Search().ToList();


        }

        [HttpGet("getDrink")]
        public IEnumerable<DrinkViewModel> MenuDrinks()
        {
            return _drinkHandler.Search().ToList();
        }

        [HttpGet("clientNoAdress")]
        public IEnumerable<ClientViewModel> GetClientNoAdress()
        {
            return _clientHandler.GetClientNoAdress().ToList();
        }

        [HttpGet("clients")]
        public IEnumerable<ClientViewModelWithAdress> GetClients()
        {
            return _clientHandler.GetClientsWithAdress().ToList();
        }

        

        [HttpGet("adress/{CPFId}")]
        public IActionResult GetAdress(string CPFId)
        {
            AdressViewModel adress = _adressHandler.GetAdressByCPF(CPFId);

            if (adress.ClientId == null)
            {
                return NotFound("Endereço não encontrado!");
            }
            
            return Ok(adress);
        }



        #endregion

        #region "POST"
        [HttpPost("addPizza")]

        public IActionResult CreatePizza([FromBody] PizzaViewModel pizzaModel)
        {
            if (pizzaModel == null)
            {
                return NotFound();
            }
            _pizzaHandler.Add(pizzaModel);

            return Ok(pizzaModel);

        }

        [HttpPost("addDrink")]

        public IActionResult CreateDrink([FromBody] DrinkViewModel drinkModel)
        {
            if (drinkModel == null)
            {
                return NotFound();
            }
            _drinkHandler.Add(drinkModel);

            return Ok(drinkModel);

        }

        [HttpPost("addClient")]
        public IActionResult AddClient([FromBody] ClientViewModelAdd client)
        {
            if (client == null)
            {
                return BadRequest("Objeto nulo ou fora do padrão");
            }

            _clientHandler.AddClient(client);
            return Ok(client);
        }

        [HttpPost("addAdress")]
        public IActionResult AddAdress([FromBody] AdressAddViewModel adress)
        {
            Client cli = _clientHandler.GetClientByCPF(adress.ClientId);

            if (adress == null || cli == null)
            {
                return BadRequest("Objeto nulo ou fora do padrão");
            }

            _adressHandler.Add(adress); 
            return Ok(adress);
        }

        #endregion

        #region "DELETE"

        [HttpDelete("deletePizza/{idPizza}")]

        public IActionResult DeletePizzaId([FromBody] int id)
        {
            Pizza pizza = _pizzaHandler.GetById(id);

            if (pizza == null)
            {
                return NotFound("Pizza não encontrada!");
            }

            _pizzaHandler.DeleteById(id);
            return Ok("Pizza Removida!");
        }

        [HttpDelete("deleteDrink/{idDrink}")]

        public IActionResult DeleteDrinkId([FromBody] int id)
        {

            Drink drink = _drinkHandler.GetById(id);
            if (drink == null)
            {
                return NotFound("Bebida não encontrada!");
            }
            _drinkHandler.Delete(id);
            return Ok("Bebida removida");
        }

        [HttpDelete("deleteAdress/{CPFId}")]
        public IActionResult DeleteAdressById(string CPFId)
        {
            AdressViewModel verification = _adressHandler.GetAdressByCPF(CPFId);

            if(verification == null)
            {
                return NotFound("Endereço não encontrado!");
            }

            _adressHandler.Remove(CPFId);
            return Ok("Removido!");

        }

        [HttpDelete("deleteClient/{CPFId}")]
        public IActionResult DeleteClientById(string CPFId)
        {
            Client client = _clientHandler.GetClientByCPF(CPFId);
            if(client.CPFId == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            _clientHandler.RemoveClient(CPFId);

            return Ok("Removido!");
        }

        #endregion

        #region "PUT"

        [HttpPut("updateClientNoAdressNoPassword")]
        public IActionResult UpdateClientNoAdressNoPassword(ClientViewModel client)
        {
            if(client.CPFId == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            _clientHandler.UpdateClientNoAdressNoPassword(client);

            return Ok(client);
        }

        [HttpPut("updateClientPassword")]
        public IActionResult UpdateClientPassword(string CPFId, string newPassword)
        {
            if(CPFId == null || newPassword == null)
            {
                return NotFound("CPF ou Senha invalidos ou vazios.");
            }

            _clientHandler.UpdateClientPassword(CPFId, newPassword);

            return Ok("Senha alterada!");
        }

        [HttpPut("updateAdress")]
        public IActionResult UpdateAdress(AdressAddViewModel adress)
        {
            AdressViewModel verification = _adressHandler.GetAdressByCPF(adress.ClientId);

            if(verification == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            _adressHandler.Update(adress);

            return Ok(adress);
        }


        [HttpPut("updatePizza")]
        public IActionResult UpdatePizza(PizzaViewModel pizzaModel, int id)
        {
            Pizza pizza = _pizzaHandler.GetById(id);
            if(pizza == null)
            {
                return NotFound("Pizza não encontrada!");
            }

            _pizzaHandler.Update(pizzaModel, id);

            return Ok("Pizza alterada!");
        }
        #endregion

    }
}
