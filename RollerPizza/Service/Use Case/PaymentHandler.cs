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
        IItemDao<Pizza> _pizzaDao;
        IItemDao<Drink> _drinkDao;

        public PaymentHandler(PaymentDao paymentDao, ClientDao clientDao, IItemDao<Pizza> pizzaDao, IItemDao<Drink> drinkDao)
        {
            _paymentDao = paymentDao;
            _clientDao = clientDao;
            _pizzaDao = pizzaDao;
            _drinkDao = drinkDao;
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
        public void AddPayment(PaymentAddViewModel paymentAddViewModel)
        {

            Payment payament = TransformDataPayment(paymentAddViewModel);
            payament.PaymentId = payament.CPFId;

            _paymentDao.AddPayment(payament);

        }

        public void UpdateStatusPayment(string CPFId, int numberStatus)
        {
            Payment payment = _paymentDao.GetPaymentByCPF(CPFId);

            if (numberStatus == 1)
            {
                payment.StatusOrder = StatusOrder.PAGAMENTO;

            }
            else if (numberStatus == 2)
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
            List<Pizza> Pizzas = new();
            List<Drink> Drinks = new();
            PayQuantityVsValue payQuantityVsValue = new();

            foreach (var pizzaId in paymentAddViewModel.PizzasId)
            {
                Pizza pizza = _pizzaDao.GetById(pizzaId);
                Pizzas.Add(pizza);
            }

            foreach (var pizzaId in paymentAddViewModel.DrinksId)
            {
                Drink drink = _drinkDao.GetById(pizzaId);
                Drinks.Add(drink);
            }

            payQuantityVsValue = CalculateTotalPayment(Pizzas, Drinks);

            payament.CPFId = paymentAddViewModel.CPFId;
            payament.Pizzas = Pizzas;
            payament.Drinks = Drinks;
            payament.TotalPay = payQuantityVsValue.Value;
            payament.QuantityItems = payQuantityVsValue.Quantity;

            return payament;
        }

        private PayQuantityVsValue CalculateTotalPayment(List<Pizza> pizzas, List<Drink> drinks)
        {
            PayQuantityVsValue payQuantityVsValuePizzas = ArrayExtract(pizzas);
            PayQuantityVsValue payQuantityVsValueDrinks = ArrayExtract(drinks);
            PayQuantityVsValue payReturn = new();
            
            payReturn.Quantity = payQuantityVsValuePizzas.Quantity + payQuantityVsValueDrinks.Quantity;
            payReturn.Value = payQuantityVsValuePizzas.Value + payQuantityVsValueDrinks.Value;

            return payReturn;


        }

        private PayQuantityVsValue ArrayExtract<T>(List<T> itens) where T : IItem
        {
            PayQuantityVsValue payQuantityVsValue = new();

            double total = 0;
            int quantity = itens.Count;
            foreach (T item in itens)
            {
                total += item.Value * quantity;
            }

            payQuantityVsValue.Quantity = itens.Count();
            payQuantityVsValue.Value = total;
            return payQuantityVsValue;
        }
        #endregion


    }
}
