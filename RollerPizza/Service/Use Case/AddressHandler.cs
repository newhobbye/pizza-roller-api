using RollerPizza.Data.Dao;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;

namespace RollerPizza.Service.Use_Case
{
    public class AddressHandler
    {
        private AddressDao _adressDao;

        public AddressHandler(AddressDao adressDao)
        {
            _adressDao = adressDao;
        }



        #region"GET"

        public AddressViewModel GetAddressByCPF(string cpf)
        {
            Address adress = _adressDao.GetAddressByCPF(cpf);
            AddressViewModel adressViewModel = new();

            if(adress == null) return adressViewModel;

            adressViewModel.AddressId = adress.AddressId;
            adressViewModel.CEP = adress.CEP;
            adressViewModel.City = adress.City;
            adressViewModel.District = adress.District;
            adressViewModel.Street = adress.Street;
            adressViewModel.Number = adress.Number;
            adressViewModel.Description = adress.Description;
            adressViewModel.ClientId = adress.ClientId;

            return adressViewModel;
        }

        #endregion

        #region"Add&Update"

        public void Update(AddressAddViewModel addressAddViewModel)
        {
            Address add = _adressDao.GetAddressByCPF(addressAddViewModel.ClientId);

            add.CEP = addressAddViewModel.CEP;
            add.City = addressAddViewModel.City;
            add.District = addressAddViewModel.District;
            add.Street = addressAddViewModel.Street;
            add.Number = addressAddViewModel.Number;
            add.Description = addressAddViewModel.Description;

            _adressDao.Update(add);

        }

        public void Add(AddressAddViewModel addressViewModel)
        {
            Address adress = new();

            adress.CEP = addressViewModel.CEP;
            adress.City = addressViewModel.City;
            adress.District = addressViewModel.District;
            adress.Street = addressViewModel.Street;
            adress.Number = addressViewModel.Number;
            adress.Description = addressViewModel.Description;
            adress.ClientId = addressViewModel.ClientId;

            //adress.AdressId = adress.ClientId;
            _adressDao.Add(adress);
            


        }

        #endregion

        #region"Remove"
        public void Remove(string CPFId)
        {
            Address address = _adressDao.GetAddressByCPF(CPFId);
            _adressDao.Remove(address);
        }

        #endregion





    }
}
