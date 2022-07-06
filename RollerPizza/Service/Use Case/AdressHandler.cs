using RollerPizza.Data.Dao;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;

namespace RollerPizza.Service.Use_Case
{
    public class AdressHandler
    {
        private AdressDao _adressDao;

        public AdressHandler(AdressDao adressDao)
        {
            _adressDao = adressDao;
        }



        #region"GET"

        public AdressViewModel GetAdressByCPF(string cpf)
        {
            Adress adress = _adressDao.GetAdressByCPF(cpf);
            AdressViewModel adressViewModel = new();

            if(adress == null) return adressViewModel;

            adressViewModel.AdressId = adress.AdressId;
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

        public void Update(AdressAddViewModel adressAddViewModel)
        {
            Adress add = _adressDao.GetAdressByCPF(adressAddViewModel.ClientId);

            add.CEP = adressAddViewModel.CEP;
            add.City = adressAddViewModel.City;
            add.District = adressAddViewModel.District;
            add.Street = adressAddViewModel.Street;
            add.Number = adressAddViewModel.Number;
            add.Description = adressAddViewModel.Description;

            _adressDao.Update(add);

        }

        public void Add(AdressAddViewModel adressViewModel)
        {
            Adress adress = new();

            adress.CEP = adressViewModel.CEP;
            adress.City = adressViewModel.City;
            adress.District = adressViewModel.District;
            adress.Street = adressViewModel.Street;
            adress.Number = adressViewModel.Number;
            adress.Description = adressViewModel.Description;
            adress.ClientId = adressViewModel.ClientId;

            //adress.AdressId = adress.ClientId;
            _adressDao.Add(adress);
            


        }

        #endregion

        #region"Remove"
        public void Remove(string CPFId)
        {
            Adress adress = _adressDao.GetAdressByCPF(CPFId);
            _adressDao.Remove(adress);
        }

        #endregion





    }
}
