using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RollerPizza.Model
{
    public class Address
    {
        
        public string? AddressId { get; set; }
        public string? CEP { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public int? Number { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public virtual Client? Client { get; set; }
        public string? ClientId { get; set; }



    }
}
