using Microsoft.AspNetCore.Mvc;
using RollerPizza.Data.Dao;
using RollerPizza.Model;

namespace RollerPizza.Controllers
{
    [ApiController]
    [Route("api/pizza/admin/")]
    public class PizzaRollerController : Controller
    {

        private IItemDao<Pizza> _pizzaDao;
        private IItemDao<Drink> _drinkDao;
        
        public PizzaRollerController(IItemDao<Pizza> pizzaDao, IItemDao<Drink> drinkDao)
        {
            _pizzaDao = pizzaDao;
            _drinkDao = drinkDao;
            
        }

       
        [HttpGet("getPizza")]
        public IEnumerable<Pizza> MenuPizzas()
        {
           return _pizzaDao.Search();
           
            
        }

        [HttpGet("getDrink")]
        public IEnumerable<Drink> MenuDrinks()
        {
            return _drinkDao.Search();
        }
       
        
        
        [HttpPost("addPizza")]
        
        public IActionResult CreatePizza(Pizza pizza)
        {
            if(pizza == null)
            {
                return NotFound();
            }

            _pizzaDao.Add(pizza);
            return Ok(pizza);
            
        }

        [HttpPost("addDrink")]

        public IActionResult CreateDrink(Drink drink)
        {
            if (drink == null)
            {
                return NotFound();
            }

            _drinkDao.Add(drink);
            return Ok(drink);

        }

        [HttpDelete("deletePizza/{idPizza}")]

        public IActionResult DeletePizzaId(int id)
        {
            Pizza pizza = _pizzaDao.GetById(id);

            if(pizza == null)
            {
                return NotFound("Pizza não encontrada!");
            }
            
            _pizzaDao.DeleteById(id);
             return Ok("Pizza Removida!");
        }

        [HttpDelete("deleteDrink/{idDrink}")]

        public IActionResult DeleteDrinkId(int id)
        {
            
            Drink drink = _drinkDao.GetById(id);
            if(drink == null)
            {
                return NotFound("Bebida não encontrada!");
            }
            _drinkDao.DeleteById(id);
            return Ok("Bebida removida");
        }

    }
}
