using RollerPizza.Data.Dao;
using RollerPizza.Model;

namespace RollerPizza.Service.Use_Case
{
    public class PayamentHandler
    {
        PayamentDao _payamentDao;
        ClientDao _clientDao;

        public PayamentHandler(PayamentDao payamentDao, ClientDao clientDao)
        {
            _payamentDao = payamentDao;
            _clientDao = clientDao;
        }

        public IEnumerable<Payament> GetPayamentByCPF(string cpf)
        {
            return _payamentDao.GetPayamentByCPF(cpf);
        }
        public IEnumerable<Payament> GetAllPayaments()
        {
            return _payamentDao.GetAll();
        }

        public IEnumerable<Payament> GetAllStatusShoppingKart()
        {
           return _payamentDao.GetAllStatusShoppingKart();
        }

        public IEnumerable<Payament> GetAllStatusPayament()
        {
            return _payamentDao.GetAllStatusPayament();
        }

        public IEnumerable<Payament> GetAllStatusPay()
        {
            return _payamentDao.GetAllStatusPay();
        }

        public IEnumerable<Payament> GetAllStatusFinished()
        {
            return _payamentDao.GetAllStatusFinished();
        }

        public void RemoveOneByCPF(string cpf)
        {
            _payamentDao.RemoveOneByCPF(cpf);
        }

        public void RemoveAllPayamentsByCPF(string cpf)
        {
            _payamentDao.RemoveAllPayamentsByCPF(cpf);
        }

        public void AddPayament(Client client, Payament payament)
        {
            payament.PayamentId = client.CPFId;
            payament.CPFId = client.CPFId;
            client.PayamentItems.Add(payament);
            _clientDao.Add(client);
            _payamentDao.AddPayament(payament); 
            
        }

    }
}
