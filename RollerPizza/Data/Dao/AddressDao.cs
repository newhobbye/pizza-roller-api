using Microsoft.EntityFrameworkCore;
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

        #region"GET"
        public Address GetAddressByCPF(string cpf)
        {
            return _dbContext.Addresses.AsNoTracking().FirstOrDefault(a => a.ClientId.Equals(cpf));
        }

        #endregion

        #region"Update&Add"
        public void Update(Address address)
        {
            _dbContext.Addresses.Update(address);
            _dbContext.SaveChanges();
        }

        public void Add(Address address)
        {
            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();
        }
        #endregion

        #region"Remove"
        public void Remove(Address address)
        {
            _dbContext.Addresses.Remove(address);
            _dbContext.SaveChanges();
        }

        #endregion
        

        
    }
}
