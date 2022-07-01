using RollerPizza.Data.Dao;
using RollerPizza.Model;

namespace RollerPizza.Service.Use_Case
{
    public class ClientHandler
    {
        private ClientDao _clientDao;
        private AdressDao _adressDao;
        private PayamentDao _payamentDao;

        public ClientHandler(ClientDao clientDao, AdressDao adressDao, PayamentDao payamentDao)
        {
            _clientDao = clientDao;
            _adressDao = adressDao;
            _payamentDao = payamentDao;
        }



        public IEnumerable<Client> GetClients()
        {
            List<Client> clients = _clientDao.GetClients().ToList();
            List<Client> result = new();

            foreach (var item in clients)
            {
                Client? client = item;
                client.Adress = _adressDao.GetAdressByCPF(item.CPFId);
                client.PayamentItems = _payamentDao.GetPayamentByCPF(item.CPFId).ToList();
                result.Add(client);
            }

            return result;
        }
        public IEnumerable<Client> GetTestClient()
        {
            return _clientDao.GetClients().ToList();
        }

        public Client GetClientByCPF(string cpf)
        {
            Client? client = _clientDao.GetClientByCPF(cpf);
            client.Adress = _adressDao.GetAdressByCPF(cpf);
            client.PayamentItems = _payamentDao.GetPayamentByCPF(cpf).ToList();

            return client;

        }

        public void AddClient(Client client)
        {
            client.Adress.AdressId = client.CPFId;
            
            _clientDao.Add(client);
            //_adressDao.Add(client.Adress);
              
        }

        public void RemoveClient(string cpf)
        {
            Client client = _clientDao.GetClientByCPF(cpf);
            Adress adress = _adressDao.GetAdressByCPF(cpf);
            _clientDao.Remove(client);
            _adressDao.Remove(adress);
            
            
        }

        public void RemoveClientAndPayaments(string cpf)
        {
            Client client = _clientDao.GetClientByCPF(cpf);
            Adress adress = _adressDao.GetAdressByCPF(cpf);
            _clientDao.Remove(client);
            _adressDao.Remove(adress);
            _payamentDao.RemoveAllPayamentsByCPF(cpf);


        }

        public void UpdateClient(Client client)
        {
            Client cli = GetClientByCPF(client.CPFId);

            
            cli.Name = client.Name;
            cli.NickName = client.NickName;
            cli.Password = client.Password;
            cli.Email = client.Email;
            cli.Adress = client.Adress;

            _clientDao.Update(cli);
            _adressDao.Update(cli.Adress);
        }

        
    }
}
