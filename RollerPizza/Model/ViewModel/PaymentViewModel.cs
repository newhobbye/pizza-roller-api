using RollerPizza.Enums;

namespace RollerPizza.Model.ViewModel
{
    public class PaymentViewModel
    {
        public string? PaymentId { get; set; }
        public virtual List<Pizza>? Pizzas { get; set; }
        public virtual List<Drink>? Drinks { get; set; }
        public string? CPFId { get; set; }
        public double? TotalPay { get; set; }
        public DateTime? DateTransaction { get; set; }
        public virtual StatusOrder? StatusOrder { get; set; }
    }

    public class PaymentAddViewModel
    {
        public string? CPFId { get; set; }
        public virtual int[] PizzasId { get; set; }
        public virtual int[] DrinksId { get; set; }
        
    }

    public class PayQuantityVsValue
    {
        public int Quantity { get; set; }
        public double Value { get; set; }
    }

    
}
