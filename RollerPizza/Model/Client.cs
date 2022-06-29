namespace RollerPizza.Model
{
    public class Client
    {
        public string CPFId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AdressId { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual List<Payament> PayamentItems { get; set; }


        
    }
}
