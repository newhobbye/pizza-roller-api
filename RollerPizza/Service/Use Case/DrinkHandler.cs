using RollerPizza.Data.Dao;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;

namespace RollerPizza.Service.Use_Case
{
    public class DrinkHandler
    {
        private IItemDao<Drink> _drinkDao;


        public DrinkHandler(IItemDao<Drink> drinkDao)
        {
            _drinkDao = drinkDao;
        }

        #region"GET"

        public DrinkViewModel GetByIdModel(int id)
        {
            Drink drink = _drinkDao.GetById(id);
            DrinkViewModel drinkModel = new();

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

        public DrinkViewModel GetByName(string name)
        {
            Drink drink = _drinkDao.Search().Where(d => d.Name.ToUpper().Contains(name.ToUpper())).FirstOrDefault();
            DrinkViewModel drinkModel = new();

            drinkModel.Id = drink.Id;
            drinkModel.Name = drink.Name;
            drinkModel.Description = drink.Description;
            drinkModel.Quantity = drink.Quantity;
            drinkModel.Value = drink.Value;

            return drinkModel;
        }

        public IEnumerable<DrinkViewModel> Search()
        {
            List<Drink> drinks = _drinkDao.Search().ToList();
            List<DrinkViewModel> drinkModels = new();

            foreach (Drink drink in drinks)
            {
                DrinkViewModel drinkModel = new();

                drinkModel.Id = drink.Id;
                drinkModel.Name = drink.Name;
                drinkModel.Description = drink.Description;
                drinkModel.Quantity = drink.Quantity;
                drinkModel.Value = drink.Value;

                drinkModels.Add(drinkModel);
            }
            return drinkModels;
        }

        #endregion

        #region"Add&Update"
        public void Add(DrinkViewModel drinkModel)
        {
            Drink drink = new();

            drink.Id = drinkModel.Id;
            drink.Name = drinkModel.Name;
            drink.Description = drinkModel.Description;
            drink.Quantity = drinkModel.Quantity;
            drink.Value = drinkModel.Value;

            _drinkDao.Add(drink);
        }

        public void Update(DrinkViewModel drinkModel, int id)
        {
            Drink drink = _drinkDao.GetById(id);

            drink.Id = drinkModel.Id;
            drink.Name = drinkModel.Name;
            drink.Description = drinkModel.Description;
            drink.Quantity = drinkModel.Quantity;
            drink.Value = drinkModel.Value;

            _drinkDao.Update(drink);
        }

        #endregion

        #region"Delete"

        public void Delete(int id)
        {
            Drink drink = _drinkDao.GetById(id);
            _drinkDao.Delete(drink);
        }

        #endregion
    }
}
