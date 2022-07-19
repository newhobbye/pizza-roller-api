using Microsoft.EntityFrameworkCore;
using RollerPizza.Model;

namespace RollerPizza.Data.Dao
{
    public class DrinkDao : IItemDao<Drink>
    {

        private DBContext _drinkContext;

        public DrinkDao(DBContext drinkContext)
        {
            _drinkContext = drinkContext;
        }

        #region"GET"
        public Drink GetById(int id)
        {
            return _drinkContext.Drinks.AsNoTracking().Where(drink => drink.Id == id).FirstOrDefault();
        }

        public IEnumerable<Drink> Search()
        {
            return _drinkContext.Drinks.AsNoTracking().ToList();
        }
        #endregion

        #region"Update&Add"
        public void Add(Drink drink)
        {

            _drinkContext.Drinks.Add(drink);
            _drinkContext.SaveChanges();

        }

        public void Update(Drink drink)
        {
            _drinkContext.Drinks.Update(drink);
            _drinkContext.SaveChanges();
        }
        #endregion

        #region"Remove"
        public void Delete(Drink drink)
        {

            _drinkContext.Drinks.Remove(drink);
            _drinkContext.SaveChanges();


        }
        #endregion

    }
}
