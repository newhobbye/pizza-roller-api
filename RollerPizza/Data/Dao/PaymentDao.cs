using Microsoft.EntityFrameworkCore;
using RollerPizza.Model;

namespace RollerPizza.Data.Dao
{
    public class PaymentDao
    {
        private DBContext _dbContext;

        public PaymentDao(DBContext dbContext)
        {
            _dbContext = dbContext;
        }


        #region"GET"

        public IEnumerable<Payment> GetPaymentsByCPF(string cpf)
        {
            return _dbContext.Payments.AsNoTracking().Where(p => p.CPFId.Equals(cpf)).ToList();
        }

        public Payment GetPaymentByCPF(string cpf)
        {
            return _dbContext.Payments.AsNoTracking().Where(p => p.CPFId.Equals(cpf)).FirstOrDefault();
        }

        public IEnumerable<Payment> GetAll()
        {
            return _dbContext.Payments.AsNoTracking().ToList();
        }

        public IEnumerable<Payment> GetAllStatusShoppingKart()
        {
            return _dbContext.Payments.AsNoTracking().Where(p => p.StatusOrder.ToString().Equals("CARRINHO")).ToList();
        }

        public IEnumerable<Payment> GetAllStatusPayment()
        {
            return _dbContext.Payments.AsNoTracking().Where(p => p.StatusOrder.ToString().Equals("PAGAMENTO")).ToList();
        }

        public IEnumerable<Payment> GetAllStatusPay()
        {
            return _dbContext.Payments.AsNoTracking().Where(p => p.StatusOrder.ToString().Equals("PAGO")).ToList();
        }

        public IEnumerable<Payment> GetAllStatusFinished()
        {
            return _dbContext.Payments.AsNoTracking().Where(p => p.StatusOrder.ToString().Equals("FINALIZADO")).ToList();
        }

        #endregion

        #region"Update&Add"

        public void AddPayment(Payment payment)
        {
            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
        }

        public void UpdatePayment(Payment payment)
        {
            _dbContext.Payments.Update(payment);
            _dbContext.SaveChanges();
        }

        #endregion

        #region"Remove"

        public void RemoveOneByCPF(string cpf)
        {
            Payment payament = _dbContext.Payments.FirstOrDefault(p => p.CPFId.Equals(cpf));
            _dbContext.Payments.Remove(payament);
            _dbContext.SaveChanges();
        }

        public void RemovePayament(Payment payament)
        {
            _dbContext.Payments.Remove(payament);
            _dbContext.SaveChanges();
        }

        public void RemoveAllPaymentsByCPF(string cpf)
        {
            List<Payment> payamentsClient = GetPaymentsByCPF(cpf).ToList();

            foreach (Payment payament in payamentsClient)
            {
                _dbContext.Payments.Remove(payament);
                _dbContext.SaveChanges();
            }

        }

        #endregion

    }
}
