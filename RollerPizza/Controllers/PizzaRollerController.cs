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
        private AddressHandler _addressHandler;
        private PaymentHandler _paymentHandler;

        public PizzaRollerController(PizzaHandler pizzaHandler, DrinkHandler drinkHandler,
            ClientHandler clientHandler, AddressHandler adressHandler, PaymentHandler payamentHandler)
        {
            _pizzaHandler = pizzaHandler;
            _drinkHandler = drinkHandler;
            _clientHandler = clientHandler;
            _addressHandler = adressHandler;
            _paymentHandler = payamentHandler;
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

        [HttpGet("clientNoAddress")]
        public IEnumerable<ClientViewModel> GetClientNoAddress()
        {
            return _clientHandler.GetClientNoAddress().ToList();
        }

        [HttpGet("clients")]
        public IEnumerable<ClientViewModelWithAddress> GetClients()
        {
            return _clientHandler.GetClientsWithAddress().ToList();
        }

        

        [HttpGet("address/{CPFId}")]
        public IActionResult GetAddress(string CPFId)
        {
            AddressViewModel adress = _addressHandler.GetAddressByCPF(CPFId);

            if (adress.ClientId == null)
            {
                return NotFound("Endereço não encontrado!");
            }
            
            return Ok(adress);
        }

        [HttpGet("payment/getAllPayments")]
        public IEnumerable<PaymentViewModel> GetAllPayments()
        {
            return _paymentHandler.GetAllPayments().ToList();
        }

        [HttpGet("payment/getAllPaymentsByCPF/{CPFId}")]
        public IEnumerable<PaymentViewModel> GetAllPaymentsByCPF(string CPFId)
        {
            return _paymentHandler.GetPaymentByCPF(CPFId).ToList();
        }

        [HttpGet("payment/getAllStatusShoppingKart")]
        public IEnumerable<PaymentViewModel> GetAllStatusShoppingKart()
        {
            return _paymentHandler.GetAllStatusShoppingKart().ToList();
        }

        [HttpGet("payment/getAllStatusPayament")]
        public IEnumerable<PaymentViewModel> GetAllStatusPayment()
        {
            return _paymentHandler.GetAllStatusPayment().ToList();
        }

        [HttpGet("payment/getAllStatusPay")]
        public IEnumerable<PaymentViewModel> GetAllStatusPay()
        {
            return _paymentHandler.GetAllStatusPay().ToList();
        }

        [HttpGet("payment/getAllStatusFinished")]
        public IEnumerable<PaymentViewModel> GetAllStatusFinished()
        {
            return _paymentHandler.GetAllStatusFinished().ToList();
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

        [HttpPost("addAddress")]
        public IActionResult AddAddress([FromBody] AddressAddViewModel address)
        {
            Client cli = _clientHandler.GetClientByCPF(address.ClientId);

            if (address == null || cli == null)
            {
                return BadRequest("Objeto nulo ou fora do padrão");
            }

            _addressHandler.Add(address); 
            return Ok(address);
        }

        #endregion

        #region "DELETE"

        [HttpDelete("deletePizza/{idPizza}")]

        public IActionResult DeletePizzaId(int idPizza)
        {
            Pizza pizza = _pizzaHandler.GetById(idPizza);

            if (pizza == null)
            {
                return NotFound("Pizza não encontrada!");
            }

            _pizzaHandler.DeleteById(idPizza);
            return Ok("Pizza Removida!");
        }

        [HttpDelete("deleteDrink/{idDrink}")]

        public IActionResult DeleteDrinkId(int idDrink)
        {

            Drink drink = _drinkHandler.GetById(idDrink);
            if (drink == null)
            {
                return NotFound("Bebida não encontrada!");
            }
            _drinkHandler.Delete(idDrink);
            return Ok("Bebida removida");
        }

        [HttpDelete("deleteAddress/{CPFId}")]
        public IActionResult DeleteAddressById(string CPFId)
        {
            AddressViewModel verification = _addressHandler.GetAddressByCPF(CPFId);

            if(verification == null)
            {
                return NotFound("Endereço não encontrado!");
            }

            _addressHandler.Remove(CPFId);
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


        [HttpPut("updateClientNoAddressNoPassword")]
        public IActionResult UpdateClientNoAddressNoPassword([FromBody] ClientViewModel client)
        {
            if(client.CPFId == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            _clientHandler.UpdateClientNoAddressNoPassword(client);

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

        [HttpPut("updateAddress")]
        public IActionResult UpdateAddress([FromBody] AddressAddViewModel address)
        {
            AddressViewModel verification = _addressHandler.GetAddressByCPF(address.ClientId);

            if(verification == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            _addressHandler.Update(address);

            return Ok(address);
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

        [HttpPut("updateDrink")]
        public IActionResult UpdateDrink(DrinkViewModel drinkModel, int id)
        {
            Drink drink = _drinkHandler.GetById(id);
            if (drink == null)
            {
                return NotFound("Pizza não encontrada!");
            }

            _drinkHandler.Update(drinkModel, id); 

            return Ok("Pizza alterada!");
        }
        #endregion

    }
}
