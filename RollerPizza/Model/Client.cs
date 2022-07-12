namespace RollerPizza.Model
{
    public class Client
    {
        public string? CPFId { get; set; }
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public virtual Address? Adress { get; set; }
        public virtual List<Payment>? PaymentItems { get; set; }


        
    }
}
