using Microsoft.AspNetCore.Mvc;
using RollerPizza.Model.ViewModel;
using RollerPizza.Service.Use_Case;

namespace RollerPizza.Controllers
{
    [ApiController]
    [Route("api/pizza/catalog/")]
    public class CatalogClientController : Controller
    {

        private PizzaHandler _pizzaHandler;
        private DrinkHandler _drinkHandler;

        public CatalogClientController(PizzaHandler pizzaHandler, DrinkHandler drinkHandler)
        {
            _pizzaHandler = pizzaHandler;
            _drinkHandler = drinkHandler;
        }

        [HttpGet("getAllPizzas")]
        public IEnumerable<PizzaModel> GetAllPizzas()
        {
            return _pizzaHandler.Search();
        }

        [HttpGet("getAllDrinks")]
        public IEnumerable<DrinkModel> GetAllDrinks()
        {
            return _drinkHandler.Search();
        }
    }
}
