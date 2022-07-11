namespace RollerPizza.Model.ViewModel
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
    }

    public class PizzaAddViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
