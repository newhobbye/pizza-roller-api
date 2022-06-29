using RollerPizza.Data.Dao;
using RollerPizza.Model;

namespace RollerPizza.Service.Use_Case
{
    public class PizzaHandler
    {
        private PizzaDao _pizzaDao;

        public PizzaHandler(PizzaDao pizzaDao)
        {
            _pizzaDao = pizzaDao;
        }

        public void Add(Pizza pizza)
        {
            _pizzaDao.Add(pizza);
        }

        public Pizza GetById(int id)
        {
            return _pizzaDao.GetById(id);
        }

        public Pizza GetByName(string name)
        {
            Pizza pizza = Search().Where(
                p => p.Name.ToUpper().Contains(name.ToUpper())).FirstOrDefault();

            return pizza;
        }

        public IEnumerable<Pizza> Search()
        {
            return _pizzaDao.Search();
        }

        public void Update(Pizza pizza)
        {
            _pizzaDao.Update(pizza);
        }

        public void DeleteById(int id)
        {
            Pizza pizza = _pizzaDao.GetById(id);
            _pizzaDao.Delete(pizza);

        }
    }
}