using RollerPizza.Model;
using RollerPizza.Model.ViewModel;
using RollerPizza.Service.Use_Case;


namespace RollerPizza.Service
{
    public class ShoppingKartService
    {
        private PaymentHandler _payamentHandler;

        
        public ShoppingKartService(PaymentHandler payamentHandler)
        {
            _payamentHandler = payamentHandler;
        }


        public void ProcessShoppingCard(PaymentAddViewModel payament)
        {
            _payamentHandler.AddPayment(payament);

        }

        public void RemovePaymentShoppingCard(string CPF)
        {
            _payamentHandler.RemoveOneByCPF(CPF);
        }

        public void UpdateStatusPayment(string CPFId, int numberStatus)
        {
            _payamentHandler.UpdateStatusPayment(CPFId, numberStatus);
        }
    }
}
