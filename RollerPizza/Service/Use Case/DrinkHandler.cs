using RollerPizza.Data.Dao;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;

namespace RollerPizza.Service.Use_Case
{
    public class DrinkHandler
    {
        private DrinkDao _drinkDao;

        public DrinkHandler(DrinkDao drinkDao)
        {
            _drinkDao = drinkDao;
        }

        public DrinkModel GetByIdModel(int id)
        {
            Drink drink = _drinkDao.GetById(id);
            DrinkModel drinkModel = new();

            drinkModel.Id = drink.Id;
            drinkModel.Name = drink.Name;
            drinkModel.Description = drink.Description;
            drinkModel.Quantity = drink.Quantity;
            drinkModel.Value = drink.Value;

            return drinkModel;
        }

        public Drink GetById(int id)
        {
            return _drinkDao.GetById(id);
        }

        public DrinkModel GetByName(string name)
        {
            Drink drink = _drinkDao.Search().Where(d => d.Name.ToUpper().Contains(name.ToUpper())).FirstOrDefault();
            DrinkModel drinkModel = new();

            drinkModel.Id = drink.Id;
            drinkModel.Name = drink.Name;
            drinkModel.Description = drink.Description;
            drinkModel.Quantity = drink.Quantity;
            drinkModel.Value = drink.Value;

            return drinkModel;
        }

        public IEnumerable<DrinkModel> Search()
        {
            List<Drink> drinks = _drinkDao.Search().ToList();
            List<DrinkModel> drinkModels = new();

            foreach (Drink drink in drinks)
            {
                DrinkModel drinkModel = new();

                drinkModel.Id = drink.Id;
                drinkModel.Name = drink.Name;
                drinkModel.Description = drink.Description;
                drinkModel.Quantity = drink.Quantity;
                drinkModel.Value = drink.Value;

                drinkModels.Add(drinkModel);
            }
            return drinkModels;
        }

        public void Add(DrinkModel drinkModel)
        {
            Drink drink = new();

            drink.Name = drinkModel.Name;
            drink.Description = drinkModel.Description;
            drink.Quantity = drinkModel.Quantity;
            drink.Value = drinkModel.Value;

            _drinkDao.Add(drink);
        }

        public void Update(DrinkModel drinkModel)
        {
            Drink drink = new();

            drink.Name = drinkModel.Name;
            drink.Description = drinkModel.Description;
            drink.Quantity = drinkModel.Quantity;
            drink.Value = drinkModel.Value;

            _drinkDao.Update(drink);
        }

        public void Delete(int id)
        {
            Drink drink = _drinkDao.GetById(id);
            _drinkDao.Delete(drink);
        }
    }
}
