using Microsoft.AspNetCore.Mvc;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;
using RollerPizza.Service.Use_Case;

namespace RollerPizza.Controllers
{
    [ApiController]
    [Route("api/pizza/admin/")]
    public class PizzaRollerController : Controller
    {

        private PizzaHandler _pizzaHandler;
        private DrinkHandler _drinkHandler;
        private ClientHandler _clientHandler;

        public PizzaRollerController(PizzaHandler pizzaHandler, DrinkHandler drinkHandler, ClientHandler clientHandler)
        {
            _pizzaHandler = pizzaHandler;
            _drinkHandler = drinkHandler;
            _clientHandler = clientHandler;
        }

        [HttpGet("getPizza")]
        public IEnumerable<PizzaModel> MenuPizzas()
        {
           return _pizzaHandler.Search().ToList();
           
            
        }

        [HttpGet("getDrink")]
        public IEnumerable<DrinkModel> MenuDrinks()
        {
            return _drinkHandler.Search().ToList();
        }
       
        
        
        [HttpPost("addPizza")]
        
        public IActionResult CreatePizza(PizzaModel pizzaModel)
        {
            if(pizzaModel == null)
            {
                return NotFound();
            }
            _pizzaHandler.Add(pizzaModel);
            
            return Ok(pizzaModel);
            
        }

        [HttpPost("addDrink")]

        public IActionResult CreateDrink(DrinkModel drinkModel)
        {
            if (drinkModel == null)
            {
                return NotFound();
            }
            _drinkHandler.Add(drinkModel);
           
            return Ok(drinkModel);

        }

        [HttpDelete("deletePizza/{idPizza}")]

        public IActionResult DeletePizzaId(int id)
        {
            Pizza pizza = _pizzaHandler.GetById(id);

            if(pizza == null)
            {
                return NotFound("Pizza não encontrada!");
            }
            
            _pizzaHandler.DeleteById(id);
             return Ok("Pizza Removida!");
        }

        [HttpDelete("deleteDrink/{idDrink}")]

        public IActionResult DeleteDrinkId(int id)
        {
            
            Drink drink = _drinkHandler.GetById(id);
            if(drink == null)
            {
                return NotFound("Bebida não encontrada!");
            }
            _drinkHandler.Delete(id);
            return Ok("Bebida removida");
        }

        [HttpPost("addClient")]
        public IActionResult AddClient(Client client)
        {
            if(client == null)
            {
                return BadRequest("Objeto nulo ou fora do padrão");
            }

            _clientHandler.AddClient(client);
            return Ok(client);
        }

    }
}
