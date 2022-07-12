using RollerPizza.Model;

namespace RollerPizza.Data.Dao
{
    public class AddressDao
    {
        private DBContext _dbContext;

        public AddressDao(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Address GetAddressByCPF(string cpf)
        {
            return _dbContext.Addresses.FirstOrDefault(a => a.ClientId.Equals(cpf));
        }

        public void Update(Address address)
        {
            _dbContext.Addresses.Update(address);
            _dbContext.SaveChanges();
        }

        public void Remove(Address address)
        {
            _dbContext.Addresses.Remove(address);
            _dbContext.SaveChanges();
        }

        public void Add(Address address)
        {
            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();
        }
    }
}
