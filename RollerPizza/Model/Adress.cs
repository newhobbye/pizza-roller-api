namespace RollerPizza.Model
{
    public class Adress
    {
        public string Adress_ID { get; set; }
        public string CEP { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string CPF_ID { get; set; }
        public Client Client { get; set; }

        
    }
}
