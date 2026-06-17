using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BJB.Dashboard.Service.Services.Payment;
using BJB.Dashboard.Library.Message.Response;

namespace BJB.Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ResponseEntity response = new ResponseEntity();

            var payments = await _paymentService.GetAll();
            response.success = true;
            response.result = payments;
            return Ok(response);
        }
    }
}
