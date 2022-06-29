using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollerPizza.Model
{
    public class Adress
    {
        
        public string AdressId { get; set; }
        public int CEP { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public virtual Client Client { get; set; }

        
    }
}
