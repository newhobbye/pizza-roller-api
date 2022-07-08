using RollerPizza.Data.Dao;
using RollerPizza.Enums;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;

namespace RollerPizza.Service.Use_Case
{
    public class PayamentHandler
    {
        PayamentDao _payamentDao;
        ClientDao _clientDao;

        public PayamentHandler(PayamentDao payamentDao, ClientDao clientDao)
        {
            _payamentDao = payamentDao;
            _clientDao = clientDao;
        }

        #region"GET"

        public IEnumerable<PayamentViewModel> GetPayamentByCPF(string cpf)
        {
            List<Payament> payaments = _payamentDao.GetPayamentsByCPF(cpf).ToList();
            List<PayamentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        public PayamentViewModel GetOnePayamentByCPF(string cpf)
        {
            Payament payament = _payamentDao.GetPayamentByCPF(cpf);
            PayamentViewModel payamentViewModel = new();

            payamentViewModel.PayamentId = payament.PayamentId;
            payamentViewModel.Pizzas = payament.Pizzas;
            payamentViewModel.Drinks = payament.Drinks;
            payamentViewModel.CPFId = payament.CPFId;
            payamentViewModel.TotalPay = payament.TotalPay;
            payamentViewModel.DateTransaction = payament.DateTransaction;
            payamentViewModel.StatusOrder = payament.StatusOrder;

            return payamentViewModel;
        }

        public IEnumerable<PayamentViewModel> GetAllPayaments()
        {
            List<Payament> payaments = _payamentDao.GetAll().ToList();
            List<PayamentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        public IEnumerable<PayamentViewModel> GetAllStatusShoppingKart()
        {
            List<Payament> payaments = _payamentDao.GetAllStatusShoppingKart().ToList();
            List<PayamentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        public IEnumerable<PayamentViewModel> GetAllStatusPayament()
        {
            List<Payament> payaments = _payamentDao.GetAllStatusPayament().ToList();
            List<PayamentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        public IEnumerable<PayamentViewModel> GetAllStatusPay()
        {
            List<Payament> payaments = _payamentDao.GetAllStatusPay().ToList();
            List<PayamentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        public IEnumerable<PayamentViewModel> GetAllStatusFinished()
        {
            List<Payament> payaments = _payamentDao.GetAllStatusFinished().ToList();
            List<PayamentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        private List<PayamentViewModel> TransformData(List<Payament> payaments)
        {
            List<PayamentViewModel> payamentViewModels = new();

            foreach (var payament in payaments)
            {
                PayamentViewModel payamentViewModel = new();

                payamentViewModel.PayamentId = payament.PayamentId;
                payamentViewModel.Pizzas = payament.Pizzas;
                payamentViewModel.Drinks = payament.Drinks;
                payamentViewModel.CPFId = payament.CPFId;
                payamentViewModel.TotalPay = payament.TotalPay;
                payamentViewModel.DateTransaction = payament.DateTransaction;
                payamentViewModel.StatusOrder = payament.StatusOrder;

                payamentViewModels.Add(payamentViewModel);
            }
            return payamentViewModels;
        }

        #endregion

        #region"Add&Update"
        public void AddPayament(Client client, PayamentAddViewModel payamentAddViewModel)
        {
            Payament payament = TransformDataPayament(payamentAddViewModel);
            payament.PayamentId = client.CPFId;
            payament.CPFId = client.CPFId;

            client.PayamentItems.Add(payament);
            _clientDao.Add(client);
            _payamentDao.AddPayament(payament);

        }

        public void UpdateStatusPayament(string CPFId, int numberStatus)
        {
            Payament payament = _payamentDao.GetPayamentByCPF(CPFId);

            if (numberStatus == 1)
            {
                payament.StatusOrder = StatusOrder.CARRINHO;

            }
            else if (numberStatus == 2)
            {
                payament.StatusOrder = StatusOrder.PAGAMENTO;
            }
            else if (numberStatus == 3)
            {
                payament.StatusOrder = StatusOrder.PAGO;
            }
            else
            {
                payament.StatusOrder = StatusOrder.FINALIZADO;
            }

            _payamentDao.UpdatePayament(payament);
            //DEPOIS, TROCAR ESSES IFS POR UM STRATEGY COM CHAIN OF RESPONSIBILITY
        }
        #endregion

        #region"Remove"
        public void RemoveOneByCPF(string cpf)
        {
            Payament payament = _payamentDao.GetPayamentByCPF(cpf);
            Client client = _clientDao.GetClientByCPF(cpf);

            client.PayamentItems.Remove(payament);
            _payamentDao.RemovePayament(payament);
            _clientDao.Update(client);

        }

        public void RemoveAllPayamentsByCPF(string cpf)
        {
            Client client = _clientDao.GetClientByCPF(cpf);
            client.PayamentItems = null;
            _payamentDao.RemoveAllPayamentsByCPF(cpf);
            _clientDao.Update(client);
        }
        #endregion

        #region"Casos de uso da classe"

        private Payament TransformDataPayament(PayamentAddViewModel payamentAddViewModel)
        {
            Payament payament = new();

            payament.PayamentId = payamentAddViewModel.PayamentId;
            payament.Pizzas = payamentAddViewModel.Pizzas;
            payament.Drinks = payamentAddViewModel.Drinks;
            payament.TotalPay = payamentAddViewModel.TotalPay;

            return payament;
        }

        #endregion


    }
}
