namespace RollerPizza.Model
{
    public class Drink : IItem
    {
        public Drink(int iD, string name, string description, int quantity, double value)
        {
            ID = iD;
            Name = name;
            Description = description;
            Quantity = quantity;
            Value = value;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
    }
}
