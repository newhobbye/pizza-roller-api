using RollerPizza.Data.Dao;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;

namespace RollerPizza.Service.Use_Case
{
    public class PizzaHandler
    {
        private IItemDao<Pizza> _pizzaDao;

        public PizzaHandler(IItemDao<Pizza> pizzaDao)
        {
            _pizzaDao = pizzaDao;
        }

        #region"GET"

        public PizzaViewModel GetByIdModel(int id)
        {
            Pizza p = _pizzaDao.GetById(id);
            PizzaViewModel pizza = new();
            pizza.Id = p.Id;
            pizza.Name = p.Name;
            pizza.Description = p.Description;
            pizza.Quantity = p.Quantity;
            pizza.Value = p.Value;
            return pizza;
        }

        public Pizza GetById(int id)
        {
            return _pizzaDao.GetById(id);
        }

        public PizzaViewModel GetByName(string name)
        {
            Pizza pizza = _pizzaDao.Search().Where(
                p => p.Name.ToUpper().Contains(name.ToUpper())).FirstOrDefault();

            PizzaViewModel pizzaModel = new();
            pizzaModel.Id = pizza.Id;
            pizzaModel.Name = pizza.Name;
            pizzaModel.Description = pizza.Description;
            pizzaModel.Quantity = pizza.Quantity;
            pizzaModel.Value = pizza.Value;

            return pizzaModel;
        }

        public IEnumerable<PizzaViewModel> Search()
        {
            List<Pizza> pizzas = _pizzaDao.Search().ToList();
            List<PizzaViewModel> pizzaModels = new();

            foreach (var pizza in pizzas)
            {
                PizzaViewModel item = new();
                item.Id = pizza.Id;
                item.Name = pizza.Name;
                item.Description = pizza.Description;
                item.Quantity = pizza.Quantity;
                item.Value = pizza.Value;

                pizzaModels.Add(item);
            }
            return pizzaModels;
        }

        #endregion

        #region"Add&Update"

        public void Add(PizzaViewModel pizzaModel)
        {
            Pizza pizza = new();

            pizza.Id = pizzaModel.Id;
            pizza.Name = pizzaModel.Name;
            pizza.Description = pizzaModel.Description;
            pizza.Quantity = pizzaModel.Quantity;
            pizza.Value = pizzaModel.Value;

            _pizzaDao.Add(pizza);
        }



        public void Update(PizzaViewModel pizzaModel, int id)
        {
            Pizza pizza = _pizzaDao.GetById(id);

            pizza.Name = pizzaModel.Name;
            pizza.Description = pizzaModel.Description;
            pizza.Quantity = pizzaModel.Quantity;
            pizza.Value = pizzaModel.Value;

            _pizzaDao.Update(pizza);
        }

        #endregion

        #region"Remove"
        public void DeleteById(int id)
        {
            Pizza pizza = _pizzaDao.GetById(id);
            _pizzaDao.Delete(pizza);

        }

        #endregion
    }
}