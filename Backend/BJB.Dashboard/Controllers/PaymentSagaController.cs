using BJB.Dashboard.Library.Message.Response;
using BJB.Dashboard.Service.Services.PaymentSaga;
using Microsoft.AspNetCore.Mvc;

namespace BJB.Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentSagaController : ControllerBase
    {
        private readonly ILogger<PaymentSagaController> _logger;
        private readonly IPaymentSagaService _paymentSagaService;

        public PaymentSagaController(ILogger<PaymentSagaController> logger, IPaymentSagaService paymentSagaService)
        {
            _logger = logger;
            _paymentSagaService = paymentSagaService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ResponseEntity response = new ResponseEntity();

            var payments = await _paymentSagaService.GetAll();
            response.success = true;
            response.result = payments;
            return Ok(response);
        }
    }
}
