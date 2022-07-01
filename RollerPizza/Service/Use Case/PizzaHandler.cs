using RollerPizza.Data.Dao;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;

namespace RollerPizza.Service.Use_Case
{
    public class PizzaHandler
    {
        private PizzaDao _pizzaDao;

        public PizzaHandler(PizzaDao pizzaDao)
        {
            _pizzaDao = pizzaDao;
        }

        public void Add(PizzaModel pizzaModel)
        {
            Pizza pizza = new();

            pizza.Id = pizzaModel.Id;
            pizza.Name = pizzaModel.Name;
            pizza.Description = pizzaModel.Description;
            pizza.Quantity = pizzaModel.Quantity;
            pizza.Value = pizzaModel.Value;

            _pizzaDao.Add(pizza);
        }

        public PizzaModel GetByIdModel(int id)
        {
            Pizza p = _pizzaDao.GetById(id);
            PizzaModel pizza = new();
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

        public PizzaModel GetByName(string name)
        {
            Pizza pizza = _pizzaDao.Search().Where(
                p => p.Name.ToUpper().Contains(name.ToUpper())).FirstOrDefault();

            PizzaModel pizzaModel = new();
            pizzaModel.Id = pizza.Id;
            pizzaModel.Name = pizza.Name;
            pizzaModel.Description = pizza.Description;
            pizzaModel.Quantity = pizza.Quantity;
            pizzaModel.Value = pizza.Value;

            return pizzaModel;
        }

        public IEnumerable<PizzaModel> Search()
        {
            List<Pizza> pizzas = _pizzaDao.Search().ToList();
            List<PizzaModel> pizzaModels = new();

            foreach (var pizza in pizzas)
            {
                PizzaModel item = new();
                item.Id = pizza.Id;
                item.Name = pizza.Name;
                item.Description = pizza.Description;
                item.Quantity = pizza.Quantity;
                item.Value = pizza.Value;

                pizzaModels.Add(item);
            }
            return pizzaModels;
        }

        public void Update(PizzaModel pizzaModel)
        {
            Pizza pizza = new();

            pizza.Id = pizzaModel.Id;
            pizza.Name = pizzaModel.Name;
            pizza.Description = pizzaModel.Description;
            pizza.Quantity = pizzaModel.Quantity;
            pizza.Value = pizzaModel.Value;

            _pizzaDao.Update(pizza);
        }

        public void DeleteById(int id)
        {
            Pizza pizza = _pizzaDao.GetById(id);
            _pizzaDao.Delete(pizza);

        }
    }
}