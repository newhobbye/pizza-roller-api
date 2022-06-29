using RollerPizza.Data.Dao;
using RollerPizza.Model;

namespace RollerPizza.Service.Use_Case
{
    public class AdressHandler
    {
        private AdressDao _adressDao;
        private ClientDao _clientDao;

        public AdressHandler(AdressDao adressDao, ClientDao clientDao)
        {
            _adressDao = adressDao;
            _clientDao = clientDao;
        }


        public Adress GetAdressByCPF(string cpf)
        {
            return _adressDao.GetAdressByCPF(cpf);
        }

        public void Update(Adress adress)
        {
            Adress add = new();

            add.CEP = adress.CEP;
            add.City = adress.City;
            add.District = adress.District;
            add.Street = adress.Street;
            add.Number = adress.Number;
            add.Description = adress.Description;
            
            _adressDao.Add(add);
            
        }

        public void Remove(Adress adress)
        {
            _adressDao.Remove(adress);
        }

        public void Add(Client client, Adress adress)
        {
            adress.AdressId = client.CPFId;
            //adress.CPFId = client.CPFId;
            client.Adress = adress;
            _clientDao.Add(client);
            _adressDao.Add(adress);

        }
    }
}
