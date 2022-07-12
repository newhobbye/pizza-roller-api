using System.Text.Json.Serialization;

namespace RollerPizza.Model
{
    public class Pizza : IItem
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        [JsonIgnore]
        public virtual List<Payment> Payment { get; set; }

        public Pizza()
        {
            Payment = new List<Payment>();
        }

    }
        
}
