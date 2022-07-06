using Microsoft.AspNetCore.Mvc;
using RollerPizza.Model.ViewModel;
using RollerPizza.Service.Use_Case;

namespace RollerPizza.Controllers
{
    [ApiController]
    [Route("api/pizza/catalog/")]
    public class CatalogClientController : Controller
    {


        [HttpGet("getAllPizzas")]
        public IEnumerable<PizzaViewModel> GetAllPizzas([FromServices] PizzaHandler _pizzaHandler)
        {
            return _pizzaHandler.Search();
        }

        [HttpGet("getAllDrinks")]
        public IEnumerable<DrinkViewModel> GetAllDrinks([FromServices] DrinkHandler _drinkHandler)
        {
            return _drinkHandler.Search();
        }
    }
}
