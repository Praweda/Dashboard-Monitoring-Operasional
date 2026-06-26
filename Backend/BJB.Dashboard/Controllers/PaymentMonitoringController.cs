using BJB.Dashboard.Library.Message.Response;
using BJB.Dashboard.Service.Services.PaymentMonitoring;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BJB.Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMonitoringController : ControllerBase
    {
        private readonly ILogger<PaymentMonitoringController> _logger;
        private readonly IPaymentMonitoringService _paymentMonitoringService;

        public PaymentMonitoringController(ILogger<PaymentMonitoringController> logger, IPaymentMonitoringService paymentMonitoringService)
        {
            _logger = logger;
            _paymentMonitoringService = paymentMonitoringService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ResponseEntity response = new ResponseEntity();

            var payments = await _paymentMonitoringService.GetAll();
            response.success = true;
            response.result = payments;
            return Ok(response);
        }
    }
}
