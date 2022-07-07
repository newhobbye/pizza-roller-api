using RollerPizza.Enums;

namespace RollerPizza.Model.ViewModel
{
    public class PayamentViewModel
    {
        public string? PayamentId { get; set; }
        public virtual List<Pizza>? Pizzas { get; set; }
        public virtual List<Drink>? Drinks { get; set; }
        public string? CPFId { get; set; }
        public DateTime? DateTransaction { get; set; }
        public virtual StatusOrder? StatusOrder { get; set; }
    }

    public class PayamentAddViewModel
    {
        public string? PayamentId { get; set; }
        public virtual List<Pizza>? Pizzas { get; set; }
        public virtual List<Drink>? Drinks { get; set; }
        //public string? CPFId { get; set; }


        public PayamentAddViewModel()
        {
            Pizzas = new ();
            Drinks = new ();
        }
    }
}
