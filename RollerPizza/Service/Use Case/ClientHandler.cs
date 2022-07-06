using RollerPizza.Data.Dao;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;

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


        #region "GET"

        public IEnumerable<ClientViewModelWithAdress> GetClientsWithAdress()
        {
            List<Client> clients = _clientDao.GetClients().ToList();
            List<ClientViewModelWithAdress> clientsViewModel = new();

            foreach (Client client in clients)
            {
                ClientViewModelWithAdress cli = new();

                cli.CPFId = client.CPFId;
                cli.Name = client.Name;
                cli.NickName = client.NickName;
                cli.Email = client.Email;
                cli.Adress = client.Adress;

                clientsViewModel.Add(cli);
            }

            return clientsViewModel;
        }

        public IEnumerable<ClientViewModel> GetClientNoAdress()
        {
            List<Client> client = _clientDao.GetClients().ToList();
            List<ClientViewModel> clientModel = new();

            foreach (var cli in client)
            {
                ClientViewModel model = new();

                model.CPFId = cli.CPFId;
                model.Name = cli.Name;
                model.NickName = cli.NickName;
                model.Email = cli.Email;
                clientModel.Add(model);
            }

            return clientModel;
        }

        

        public IEnumerable<ClientViewModelWithPayament> GetClientWithPayament()
        {
            List<Client> client = _clientDao.GetClients().ToList();
            List<ClientViewModelWithPayament> clientModel = new();

            foreach (var cli in client)
            {
                ClientViewModelWithPayament model = new();

                model.CPFId = cli.CPFId;
                model.Name = cli.Name;
                model.NickName = cli.NickName;
                model.Email = cli.Email;
                model.PayamentItems = cli.PayamentItems;

                clientModel.Add(model);
            }

            return clientModel;
        }

        public Client GetClientByCPF(string cpf)
        {
            Client? client = _clientDao.GetClientByCPF(cpf);
            //client.Adress = _adressDao.GetAdressByCPF(cpf);
            //client.PayamentItems = _payamentDao.GetPayamentByCPF(cpf).ToList(); VERIFICAR MAIS PRA FRENTE COMO VAI FICAR

            return client;

        }

        #endregion

        #region "Add&Update"
        public void AddClient(ClientViewModelAdd clientAdd)
        {
            
            Client client = new();

            client.CPFId = clientAdd.CPFId;
            client.Name = clientAdd.Name;
            client.NickName = clientAdd.NickName;
            client.Password = clientAdd.Password;
            client.Email = clientAdd.Email;

            _clientDao.Add(client);
            
              
        }

        public void UpdateClientNoAdressNoPassword(ClientViewModel clientModel)
        {
            Client client = _clientDao.GetClientByCPF(clientModel.CPFId);

            client.Name = clientModel.Name;
            client.NickName = clientModel.NickName;
            client.Email = clientModel.Email;

            _clientDao.Update(client);

            
        }

        public void UpdateClientPassword(string CPFId, string password)
        {
            Client client = _clientDao.GetClientByCPF(CPFId);

            client.Password = password;

            _clientDao.Update(client);
        }

        #endregion

        #region "Remove"
        public void RemoveClient(string cpf)
        {
            Client client = _clientDao.GetClientByCPF(cpf);
            Adress adress = _adressDao.GetAdressByCPF(cpf);
            _adressDao.Remove(adress);
            _clientDao.Remove(client);
            
            
        }

        public void RemoveClientAndPayaments(string cpf)
        {
            Client client = _clientDao.GetClientByCPF(cpf);
            Adress adress = _adressDao.GetAdressByCPF(cpf);
            _clientDao.Remove(client);
            _adressDao.Remove(adress);
            _payamentDao.RemoveAllPayamentsByCPF(cpf);


        }

        #endregion


    }
}
