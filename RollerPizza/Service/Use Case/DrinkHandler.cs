using RollerPizza.Data.Dao;
using RollerPizza.Model;

namespace RollerPizza.Service.Use_Case
{
    public class DrinkHandler
    {
        private DrinkDao _drinkDao;

        public DrinkHandler(DrinkDao drinkDao)
        {
            _drinkDao = drinkDao;
        }

        public Drink GetById(int id)
        {
            return _drinkDao.GetById(id);
        }

        public Drink GetByName(string name)
        {
            Drink drink = Search().Where(d => d.Name.ToUpper().Contains(name.ToUpper())).FirstOrDefault();
            return drink;
        }

        public IEnumerable<Drink> Search()
        {
            return _drinkDao.Search();
        }

        public void Add(Drink drink)
        {
            _drinkDao.Add(drink);
        }

        public void Update(Drink drink)
        {
            _drinkDao.Update(drink);
        }

        public void Delete(int id)
        {
            Drink drink = GetById(id);
            _drinkDao.Delete(drink);
        }
    }
}
