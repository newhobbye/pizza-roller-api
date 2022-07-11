namespace RollerPizza.Model.ViewModel
{
    public class DrinkViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
    }

    public class DrinkAddViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
