using RollerPizza.Model;

namespace RollerPizza.Data.Dao
{
    public class PayamentDao
    {
        private DBContext _dbContext;

        public PayamentDao(DBContext dbContext)
        {
            _dbContext = dbContext;
        }



        public IEnumerable<Payament> GetPayamentByCPF(string cpf)
        {
            return _dbContext.Payaments.Where(p => p.CPFId.Equals(cpf)).ToList();
        }

        public IEnumerable<Payament> GetAll()
        {
            return _dbContext.Payaments.ToList();
        }

        public IEnumerable<Payament> GetAllStatusShoppingKart()
        {
            return _dbContext.Payaments.Where(p => p.StatusOrder.ToString().Equals("CARRINHO")).ToList();
        }

        public IEnumerable<Payament> GetAllStatusPayament()
        {
            return _dbContext.Payaments.Where(p => p.StatusOrder.ToString().Equals("PAGAMENTO")).ToList();
        }

        public IEnumerable<Payament> GetAllStatusPay()
        {
            return _dbContext.Payaments.Where(p => p.StatusOrder.ToString().Equals("PAGO")).ToList();
        }

        public IEnumerable<Payament> GetAllStatusFinished()
        {
            return _dbContext.Payaments.Where(p => p.StatusOrder.ToString().Equals("FINALIZADO")).ToList();
        }



        public void RemoveOneByCPF(string cpf)
        {
            Payament payament = _dbContext.Payaments.FirstOrDefault(p => p.CPFId.Equals(cpf));
            _dbContext.Payaments.Remove(payament);
            _dbContext.SaveChanges();
        }

        public void RemoveAllPayamentsByCPF(string cpf)
        {
            List<Payament> payamentsClient = GetPayamentByCPF(cpf).ToList();

            foreach (Payament payament in payamentsClient)
            {
                _dbContext.Payaments.Remove(payament);
                _dbContext.SaveChanges();
            }

        }

        public void AddPayament(Payament payament)
        {
            _dbContext.Payaments.Add(payament);
            _dbContext.SaveChanges();
        }
    }
}
