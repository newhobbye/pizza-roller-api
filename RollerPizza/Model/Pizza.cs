namespace RollerPizza.Model
{
    public class Pizza : IItem
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        public virtual List<Payament> Payament { get; set; }

        public Pizza()
        {
            Payament = new List<Payament>();
        }

    }
        
}
