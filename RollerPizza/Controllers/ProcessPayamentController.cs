using Microsoft.AspNetCore.Http;
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

        private PayamentHandler _payamentHandler;
        private ClientHandler _clientHandler;
        private ShoppingCartService _shoppingCartService;

        public ProcessPayamentController(PayamentHandler payamentHandler, ClientHandler clientHandler,
            ShoppingCartService shoppingCartService)
        {
            _payamentHandler = payamentHandler;
            _clientHandler = clientHandler;
            _shoppingCartService = shoppingCartService;
        }




        #region"GET"

        [HttpGet("payament/getAllPayamentsByCPF/{CPFId}")]
        public IEnumerable<PayamentViewModel> GetAllPayamentsByCPF(string CPFId)
        {
            return _payamentHandler.GetPayamentByCPF(CPFId).ToList();
        }

        [HttpGet("payament/getOnePayamentByCPF/{CPFId}")]
        public IActionResult GetOnePayamentByCPF(string CPFId)
        {
            PayamentViewModel model = _payamentHandler.GetOnePayamentByCPF(CPFId);
            if(model == null)
            {
                return NotFound("Não existe pagamentos vinculados a este CPF!");
            }
            return Ok(model);

        }

        #endregion

        #region"POST"

        [HttpPost("payament/PostPayamentShoppingCart")]
        public IActionResult PostPayamentShoppingCart([FromBody] PayamentAddViewModel payamentAddViewModel)
        {
            Client client = _clientHandler.GetClientByCPF(payamentAddViewModel.PayamentId);

            if (client == null || payamentAddViewModel == null)
            {
                return NotFound("Pagamento ou cliente invalidos!");
            }
            _shoppingCartService.ProcessShoppingCard(client, payamentAddViewModel);
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
            _payamentHandler.UpdateStatusPayament(CPFId, numberStatus);

            return Ok("Status Alterado!");
        }

        #endregion

        #region"DELETE"

        #endregion

    }
}
