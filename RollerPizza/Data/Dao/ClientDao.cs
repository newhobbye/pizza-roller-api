using Microsoft.EntityFrameworkCore;
using RollerPizza.Model;

namespace RollerPizza.Data.Dao
{
    public class ClientDao
    {
        private DBContext _dbContext;

        public ClientDao(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region"GET"
        public IEnumerable<Client> GetClients()
        {
            return _dbContext.Clients.ToList();
        }

        public Client GetClientByCPF(string cpf)
        {
            return _dbContext.Clients.AsNoTracking().FirstOrDefault(client => client.CPFId.Equals(cpf));

        }

        #endregion

        #region"Update&Add"
        public void Add(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();

        }

        public void Update(Client client)
        {
            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
        }
        #endregion

        #region"Remove"
        public void Remove(Client client)
        {
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();

        }
        #endregion


        
    }
}
