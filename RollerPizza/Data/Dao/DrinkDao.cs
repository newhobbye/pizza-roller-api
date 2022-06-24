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

        public Drink GetById(int id)
        {
            return _drinkContext.Drinks.Where(drink => drink.ID == id).FirstOrDefault();
        }

        public Drink GetByName(string name)
        {
            Drink drink = _drinkContext.Drinks.Where(p => p.Name.ToUpper() == name.ToUpper()).FirstOrDefault();
            return drink;
        }

        public IEnumerable<Drink> Search()
        {
            return _drinkContext.Drinks.ToList();
        }

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

        public void DeleteById(int id)
        {
            Drink drink = _drinkContext.Drinks.FirstOrDefault(p => p.ID == id);

            _drinkContext.Remove(drink);
            _drinkContext.SaveChanges();


        }
    }
}
