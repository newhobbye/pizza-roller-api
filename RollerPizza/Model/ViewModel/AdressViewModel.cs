namespace RollerPizza.Model.ViewModel
{
    public class AdressViewModel
    {
        public string? AdressId { get; set; }
        public string? CEP { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public int? Number { get; set; }
        public string? Description { get; set; }
        public string? ClientId { get; set; }
    }

    public class AdressAddViewModel
    {
        public string? CEP { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public int? Number { get; set; }
        public string? Description { get; set; }
        public string? ClientId { get; set; }
    }
}
