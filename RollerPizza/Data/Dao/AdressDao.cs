using RollerPizza.Model;

namespace RollerPizza.Data.Dao
{
    public class AdressDao
    {
        private DBContext _dbContext;

        public AdressDao(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Adress GetAdressByCPF(string cpf)
        {
            return _dbContext.Adresses.FirstOrDefault(a => a.AdressId.Equals(cpf));
        }

        public void Update(Adress adress)
        {
            _dbContext.Adresses.Update(adress);
            _dbContext.SaveChanges();
        }

        public void Remove(Adress adress)
        {
            _dbContext.Adresses.Remove(adress);
            _dbContext.SaveChanges();
        }

        public void Add(Adress adress)
        {
            _dbContext.Adresses.Add(adress);
            _dbContext.SaveChanges();
        }
    }
}
