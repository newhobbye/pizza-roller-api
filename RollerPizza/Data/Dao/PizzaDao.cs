using Microsoft.EntityFrameworkCore;
using RollerPizza.Model;

namespace RollerPizza.Data.Dao
{
    public class PizzaDao : IItemDao<Pizza> 
    {
        private DBContext _pizzaContext;

        public PizzaDao(DBContext pizzaContext)
        {
            _pizzaContext = pizzaContext;
        }

        #region"GET"
        public Pizza GetById(int id)
        {
            return _pizzaContext.Pizzas.AsNoTracking().Where(pizza => pizza.Id == id).FirstOrDefault();
        }

        public IEnumerable<Pizza> Search()
        {
            return _pizzaContext.Pizzas.ToList();
        }

        #endregion

        #region"Update&Add"
        public void Add(Pizza pizza)
        {
            _pizzaContext.Pizzas.Add(pizza);
            _pizzaContext.SaveChanges();
        }

        public void Update(Pizza pizza)
        {
            _pizzaContext.Pizzas.Update(pizza);
            _pizzaContext.SaveChanges();
        }

        #endregion

        #region"Remove"
        public void Delete(Pizza pizza)
        {
            _pizzaContext.Pizzas.Remove(pizza);
            _pizzaContext.SaveChanges();
        }

        #endregion

    }
}
