using RollerPizza.Enums;

namespace RollerPizza.Model
{
    public class Client
    {
        public string CPF_ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } 
        public Adress Adress_ID { get; set; }
        public List<Payament> PayamentItems { get; set; }


        
    }
}
