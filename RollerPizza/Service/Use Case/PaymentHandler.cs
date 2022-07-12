using RollerPizza.Data.Dao;
using RollerPizza.Enums;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;

namespace RollerPizza.Service.Use_Case
{
    public class PaymentHandler
    {
        PaymentDao _paymentDao;
        ClientDao _clientDao;

        public PaymentHandler(PaymentDao paymentDao, ClientDao clientDao)
        {
            _paymentDao = paymentDao;
            _clientDao = clientDao;
        }


        #region"GET"

        public IEnumerable<PaymentViewModel> GetPaymentByCPF(string cpf)
        {
            List<Payment> payaments = _paymentDao.GetPaymentsByCPF(cpf).ToList();
            List<PaymentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        public PaymentViewModel GetOnePayamentByCPF(string cpf)
        {
            Payment payament = _paymentDao.GetPaymentByCPF(cpf);
            PaymentViewModel payamentViewModel = new();

            payamentViewModel.PaymentId = payament.PaymentId;
            payamentViewModel.Pizzas = payament.Pizzas;
            payamentViewModel.Drinks = payament.Drinks;
            payamentViewModel.CPFId = payament.CPFId;
            payamentViewModel.TotalPay = payament.TotalPay;
            payamentViewModel.DateTransaction = payament.DateTransaction;
            payamentViewModel.StatusOrder = payament.StatusOrder;

            return payamentViewModel;
        }

        public IEnumerable<PaymentViewModel> GetAllPayments()
        {
            List<Payment> payaments = _paymentDao.GetAll().ToList();
            List<PaymentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        public IEnumerable<PaymentViewModel> GetAllStatusShoppingKart()
        {
            List<Payment> payaments = _paymentDao.GetAllStatusShoppingKart().ToList();
            List<PaymentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        public IEnumerable<PaymentViewModel> GetAllStatusPayment()
        {
            List<Payment> payaments = _paymentDao.GetAllStatusPayment().ToList();
            List<PaymentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        public IEnumerable<PaymentViewModel> GetAllStatusPay()
        {
            List<Payment> payaments = _paymentDao.GetAllStatusPay().ToList();
            List<PaymentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        public IEnumerable<PaymentViewModel> GetAllStatusFinished()
        {
            List<Payment> payaments = _paymentDao.GetAllStatusFinished().ToList();
            List<PaymentViewModel> payamentViewModels = TransformData(payaments);

            return payamentViewModels;
        }

        private List<PaymentViewModel> TransformData(List<Payment> payaments)
        {
            List<PaymentViewModel> payamentViewModels = new();

            foreach (var payament in payaments)
            {
                PaymentViewModel payamentViewModel = new();

                payamentViewModel.PaymentId = payament.PaymentId;
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
        public void AddPayment(Client client, PaymentAddViewModel paymentAddViewModel)
        {

            Payment payament = new ();
            payament = TransformDataPayment(paymentAddViewModel);
            payament.TotalPay = CalculateTotalPayment(payament);
            payament.PaymentId = payament.CPFId;

            client.PaymentItems.Add(payament);
            _clientDao.Update(client);
            _paymentDao.AddPayment(payament);

        }

        public void UpdateStatusPayment(string CPFId, int numberStatus)
        {
            Payment payment = _paymentDao.GetPaymentByCPF(CPFId);

            if (numberStatus == 1)
            {
                payment.StatusOrder = StatusOrder.CARRINHO;

            }
            else if (numberStatus == 2)
            {
                payment.StatusOrder = StatusOrder.PAGAMENTO;
            }
            else if (numberStatus == 3)
            {
                payment.StatusOrder = StatusOrder.PAGO;
            }
            else
            {
                payment.StatusOrder = StatusOrder.FINALIZADO;
            }

            _paymentDao.UpdatePayment(payment);
            //DEPOIS, TROCAR ESSES IFS POR UM STRATEGY COM CHAIN OF RESPONSIBILITY
        }
        #endregion

        #region"Remove"
        public void RemoveOneByCPF(string cpf)
        {
            Payment payment = _paymentDao.GetPaymentByCPF(cpf);
            Client client = _clientDao.GetClientByCPF(cpf);

            client.PaymentItems.Remove(payment);
            _paymentDao.RemovePayament(payment);
            _clientDao.Update(client);

        }

        public void RemoveAllPaymentsByCPF(string cpf)
        {
            Client client = _clientDao.GetClientByCPF(cpf);
            client.PaymentItems = null;
            _paymentDao.RemoveAllPaymentsByCPF(cpf);
            _clientDao.Update(client);
        }
        #endregion

        #region"Casos de uso da classe"

        private Payment TransformDataPayment(PaymentAddViewModel paymentAddViewModel)
        {
            Payment payament = new();

            payament.CPFId = paymentAddViewModel.CPFId;
            payament.Pizzas = paymentAddViewModel.Pizzas;
            payament.Drinks = paymentAddViewModel.Drinks;
            payament.TotalPay = paymentAddViewModel.TotalPay;

            return payament;
        }

        private double CalculateTotalPayment(Payment payament)
        {
            double sum = 0;
            List<Pizza> pizzas = payament.Pizzas;
            List<Drink> drinks = payament.Drinks;

            sum += ArrayExtract(pizzas);
            sum += ArrayExtract(drinks);

            return sum;


        }

        private double ArrayExtract<T>(List<T> itens) where T : IItem
        {
            double total = 0;

            foreach (T item in itens)
            {
                total += item.Value * item.Quantity;
            }

            return total;
        }
        #endregion


    }
}
