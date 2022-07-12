using RollerPizza.Data.Dao;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;

namespace RollerPizza.Service.Use_Case
{
    public class ClientHandler
    {
        private ClientDao _clientDao;
        private AddressDao _addressDao;
        private PaymentDao _paymentDao;

        public ClientHandler(ClientDao clientDao, AddressDao addressDao, PaymentDao paymentDao)
        {
            _clientDao = clientDao;
            _addressDao = addressDao;
            _paymentDao = paymentDao;
        }


        #region "GET"

        public IEnumerable<ClientViewModelWithAddress> GetClientsWithAddress()
        {
            List<Client> clients = _clientDao.GetClients().ToList();
            List<ClientViewModelWithAddress> clientsViewModel = new();

            foreach (Client client in clients)
            {
                ClientViewModelWithAddress cli = new();

                cli.CPFId = client.CPFId;
                cli.Name = client.Name;
                cli.NickName = client.NickName;
                cli.Email = client.Email;
                cli.Adress = client.Adress;

                clientsViewModel.Add(cli);
            }

            return clientsViewModel;
        }

        public IEnumerable<ClientViewModel> GetClientNoAddress()
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

        

        public IEnumerable<ClientViewModelWithPayament> GetClientWithPayment()
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
                model.PaymentItems = cli.PaymentItems;

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

        public void UpdateClientNoAddressNoPassword(ClientViewModel clientModel)
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
            Address adress = _addressDao.GetAddressByCPF(cpf);
            _addressDao.Remove(adress);
            _clientDao.Remove(client);
            
            
        }

        public void RemoveClientAndPayments(string cpf)
        {
            Client client = _clientDao.GetClientByCPF(cpf);
            Address address = _addressDao.GetAddressByCPF(cpf);
            _clientDao.Remove(client);
            _addressDao.Remove(address);
            _paymentDao.RemoveAllPaymentsByCPF(cpf);


        }

        #endregion


    }
}
