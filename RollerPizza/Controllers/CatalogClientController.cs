using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollerPizza.Data.Dao;
using RollerPizza.Model;

namespace RollerPizza.Controllers
{
    [ApiController]
    [Route("api/pizza/catalog/")]
    public class CatalogClientController : Controller
    {

        private IItemDao<Pizza> _pizzaDao;
        private IItemDao<Drink> _drinkDao;

        public CatalogClientController(IItemDao<Pizza> pizzaDao, IItemDao<Drink> drinkDao)
        {
            _pizzaDao = pizzaDao;
            _drinkDao = drinkDao;
        }

        [HttpGet("getAllPizzas")]
        public IEnumerable<Pizza> GetAllPizzas()
        {
            return _pizzaDao.Search();
        }

        [HttpGet("getAllDrinks")]
        public IEnumerable<Drink> GetAllDrinks()
        {
            return _drinkDao.Search();
        }
    }
}
