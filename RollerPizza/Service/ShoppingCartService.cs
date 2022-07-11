using RollerPizza.Model;
using RollerPizza.Model.ViewModel;
using RollerPizza.Service.Use_Case;

namespace RollerPizza.Service
{
    public class ShoppingCartService
    {
        private PayamentHandler _payamentHandler;

        public ShoppingCartService(PayamentHandler payamentHandler)
        {
            _payamentHandler = payamentHandler;
        }


        public void ProcessShoppingCard(Client client, PayamentAddViewModel payament)
        {
            _payamentHandler.AddPayament(client, payament);

        }

        public void RemovePayamentShoppingCard(string CPF)
        {
            _payamentHandler.RemoveOneByCPF(CPF);
        }

        public void UpdateStatusPayament(string CPFId, int numberStatus)
        {
            _payamentHandler.UpdateStatusPayament(CPFId, numberStatus);
        }
    }
}
