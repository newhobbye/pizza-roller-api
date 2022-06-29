namespace RollerPizza.Model
{
    public class Drink : IItem
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        public string PayamentId { get; set; }
        public virtual Payament Payament { get; set; }
        
    }
}
