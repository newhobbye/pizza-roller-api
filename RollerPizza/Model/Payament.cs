using RollerPizza.Enums;
using System.ComponentModel.DataAnnotations;

namespace RollerPizza.Model
{
    public class Payament
    {
        
        public string PayamentId { get; set; }
        public virtual List<Pizza> Pizzas { get; set; }
        public virtual List<Drink> Drinks { get; set; }
        public string CPFId { get; set; }
        public virtual Client Client { get; set; }
        
        public DateTime DateTransaction { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }

        public Payament()
        {
            Pizzas = new List<Pizza>();
            Drinks = new List<Drink>();
            DateTransaction = DateTime.Now;
            StatusOrder = StatusOrder.CARRINHO;
        }

        
    }
}
