namespace RollerPizza.Model
{
    public class Drink : IItem
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        public virtual List<Payament> Payament { get; set; }

        public Drink()
        {
            Payament = new List<Payament>();
        }
        
    }
}
