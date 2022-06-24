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

        public void Add(Pizza pizza)
        {
            _pizzaContext.Pizzas.Add(pizza);
            _pizzaContext.SaveChanges();
        }

        public Pizza GetById(int id)
        {
            return _pizzaContext.Pizzas.Where(pizza => pizza.ID == id).FirstOrDefault();
        }

        public Pizza GetByName(string name)
        {
            Pizza pizza = _pizzaContext.Pizzas.Where(pizza => pizza.Name.ToUpper() == name.ToUpper()).FirstOrDefault(); 
            return pizza;
        }

        

        public IEnumerable<Pizza> Search()
        {
            return _pizzaContext.Pizzas.ToList();
        }

        public void Update(Pizza pizza)
        {
            _pizzaContext.Pizzas.Update(pizza);
            _pizzaContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Pizza pizza = _pizzaContext.Pizzas.FirstOrDefault(p => p.ID == id);

            _pizzaContext.Remove(pizza);
            _pizzaContext.SaveChanges();


        }
    }
}
