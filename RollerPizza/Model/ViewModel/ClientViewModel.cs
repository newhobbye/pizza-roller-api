namespace RollerPizza.Model.ViewModel
{

    #region"Expor dados"
    public class ClientViewModel
    {
        public string? CPFId { get; set; }
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public string? Email { get; set; }

    }

    public class ClientViewModelWithAddress
    {
        public string? CPFId { get; set; }
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public string? Email { get; set; }
        public virtual Address? Adress { get; set; }
    }

    public class ClientViewModelWithPayament
    {
        public string? CPFId { get; set; }
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public string? Email { get; set; }
        public virtual List<Payment>? PaymentItems { get; set; }
    }

    #endregion

    #region"Adiciona Dados e Manipula"

    public class ClientViewModelAdd
    {
        public string? CPFId { get; set; }
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

    }

    #endregion

}
