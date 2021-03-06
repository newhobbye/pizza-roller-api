using RollerPizza.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RollerPizza.Model
{
    public class Payment
    {
        
        public string? PaymentId { get; set; }
        public virtual List<Pizza> Pizzas { get; set; }
        public virtual List<Drink> Drinks { get; set; }
        public string? CPFId { get; set; }
        [JsonIgnore]
        public virtual Client? Client { get; set; }
        public double? TotalPay { get; set; }
        public int QuantityItems { get; set; }
        public DateTime DateTransaction { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }

        public Payment()
        {
            Pizzas = new List<Pizza>();
            Drinks = new List<Drink>();
            DateTransaction = DateTime.Now;
            StatusOrder = StatusOrder.CARRINHO;
        }

        
    }
}
