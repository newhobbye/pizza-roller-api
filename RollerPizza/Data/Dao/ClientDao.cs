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

       public IEnumerable<Client> GetClients()
        {
            return _dbContext.Clients.ToList();  
        }

        public Client GetClientByCPF(string cpf)
        {
            return _dbContext.Clients.FirstOrDefault(client => client.CPF_ID.Equals(cpf));
          
        }

        public void Add(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
             
        }

        public void Remove(Client client)
        {
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            
        }

        public void Update(Client client)
        {
            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
        }
    }
}
