using RollerPizza.Enums;

namespace RollerPizza.Model
{
    public class Payament
    {
        public string Payament_ID { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<Drink> Drinks { get; set; }
        public Client CPF_ID { get; set; }
        public DateTime DateTransaction { get; set; }
        public StatusOrder StatusOrder { get; set; }

        public Payament()
        {
            Pizzas = new List<Pizza>();
            Drinks = new List<Drink>();
            DateTransaction = DateTime.Now;
            StatusOrder = StatusOrder.CARRINHO;
        }

        
    }
}
