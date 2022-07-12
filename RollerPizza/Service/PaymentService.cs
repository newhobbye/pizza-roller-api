using RollerPizza.Enums;
using RollerPizza.Model;

namespace RollerPizza.Service
{
    public class PaymentService
    {
        
        //aqui vai ficar o metodo que vai receber o carrinho de compras e atribuir ao cliente

        public TotalPayAndQuantityModel ProcessPayament(Client client) //Client
        {
            List<Pizza> pizzas = new ();
            List<Drink> drinks = new ();

            foreach (var item in client.PaymentItems)
            {
                if ("CARRINHO".Equals(item.StatusOrder.ToString()))
                {
                    //pizzas = item.Pizzas;
                    //drinks = item.Drinks;
                }
            }
            TotalPayAndQuantityModel totalPizzas = InterateItemValue<Pizza>(pizzas);
            TotalPayAndQuantityModel totalDrinks = InterateItemValue<Drink>(drinks);

            TotalPayAndQuantityModel totalValue = new();
            totalValue.Value = totalPizzas.Value + totalDrinks.Value;
            totalValue.Quantity = totalPizzas.Quantity + totalDrinks.Quantity;

            //implementar a persistencia do cliente com o dao depois, e mudar o status
            return totalValue;
            
        }

        public TotalPayAndQuantityModel InterateItemValue<T>(List<T> array) where T : IItem
        {
            TotalPayAndQuantityModel sum = new TotalPayAndQuantityModel();

            foreach (var item in array)
            {
                sum.Value += item.Value * item.Quantity;
                sum.Quantity += item.Quantity;
            }
            return sum;
        }
    }
}
