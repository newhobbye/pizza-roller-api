using Microsoft.AspNetCore.Mvc;
using RollerPizza.Model;
using RollerPizza.Model.ViewModel;
using RollerPizza.Service;
using RollerPizza.Service.Use_Case;

namespace RollerPizza.Controllers
{
    [ApiController]
    [Route("api/pizza/processPayament")]
    public class ProcessPayamentController : Controller
    {

        private PaymentHandler _paymentHandler;
        private ClientHandler _clientHandler;
        private ShoppingKartService _shoppingKartService;

        public ProcessPayamentController(PaymentHandler payamentHandler, ClientHandler clientHandler,
            ShoppingKartService shoppingCartService)
        {
            _paymentHandler = payamentHandler;
            _clientHandler = clientHandler;
            _shoppingKartService = shoppingCartService;
        }




        #region"GET"

        [HttpGet("payment/getAllPaymentsByCPF/{CPFId}")]
        public IEnumerable<PaymentViewModel> GetAllPaymentsByCPF(string CPFId)
        {
            return _paymentHandler.GetPaymentByCPF(CPFId).ToList();
        }

        [HttpGet("payment/getOnePaymentByCPF/{CPFId}")]
        public IActionResult GetOnePaymentByCPF(string CPFId)
        {
            PaymentViewModel model = _paymentHandler.GetOnePayamentByCPF(CPFId);
            if(model == null)
            {
                return NotFound("Não existe pagamentos vinculados a este CPF!");
            }
            return Ok(model);

        }

        #endregion

        #region"POST"

        [HttpPost("payment/PostPaymentShoppingCart")]
        public IActionResult PostPaymentShoppingCart([FromBody] PaymentAddViewModel paymentAddViewModel)
        {
            Client client = _clientHandler.GetClientByCPF(paymentAddViewModel.CPFId); 

            if (client == null || paymentAddViewModel == null)
            {
                return NotFound("Cliente invalido!");
            }
            _shoppingKartService.ProcessShoppingCard(paymentAddViewModel);
            return Ok("Pagamento adicionado.");
        }

        #endregion

        #region"PUT"

        [HttpPut("payament/updatePayamentShoppingCart")]
        public IActionResult UpdatePayamentShoppingCart(string CPFId, int numberStatus)
        {
            if(CPFId == null || numberStatus > 4 || numberStatus < 1)
            {
                return NotFound("CPF ou numero de status incorreto!");
            }
            _paymentHandler.UpdateStatusPayment(CPFId, numberStatus);

            return Ok("Status Alterado!");
        }

        #endregion

        #region"DELETE"
        [HttpDelete("payment/deletePaymentByCPFOnShoppingKart/{cpf}")]
        public IActionResult DeletePaymentByCPFOnShoppingKart(string cpf)
        {
            PaymentViewModel pay = _paymentHandler.GetOnePayamentByCPF(cpf);
            if(pay == null)
            {
                return NotFound("Pagamento não encontrado!");
            }

            _paymentHandler.RemoveOneByCPF(cpf);
            return Ok("Pagamento removido!");
        }
        #endregion

    }
}
