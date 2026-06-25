using BJB.Dashboard.Library.Message.Response;
using BJB.Dashboard.Service.Services.PaymentAndHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BJB.Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentAndHistoryController : ControllerBase
    {
        private readonly ILogger<PaymentAndHistoryController> _logger;
        private readonly IPaymentAndHistoryService _paymentAndHistoryService;

        public PaymentAndHistoryController(ILogger<PaymentAndHistoryController> logger
                                            , IPaymentAndHistoryService paymentAndHistoryService)
        {
            _logger = logger;
            _paymentAndHistoryService = paymentAndHistoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ResponseEntity response = new ResponseEntity();

            var payments = await _paymentAndHistoryService.GetAll();
            response.success = true;
            response.result = payments;
            return Ok(response);
        }

        [HttpGet("FilterDaily")]
        public async Task<IActionResult> FilterDaily([FromQuery] DateTime? busDate)
        {
            ResponseEntity response = new ResponseEntity();

            if (!busDate.HasValue)
            {
                response.success = false;
                response.message = "Parameter busDate wajib diisi.";
                return BadRequest(response);
            }

            var payments = await _paymentAndHistoryService.FilterDaily(busDate.Value);
            response.success = true;
            response.result = payments;
            return Ok(response);
        }

        [HttpGet("FilterWeekly")]
        public async Task<IActionResult> FilterWeekly([FromQuery] DateTime? busDate)
        {
            ResponseEntity response = new ResponseEntity();

            if (!busDate.HasValue)
            {
                response.success = false;
                response.message = "Parameter busDate wajib diisi.";
                return BadRequest(response);
            }

            var payments = await _paymentAndHistoryService.FilterWeekly(busDate.Value);
            response.success = true;
            response.result = payments;
            return Ok(response);
        }

        [HttpGet("FilterMonthly")]
        public async Task<IActionResult> FilterMonthly([FromQuery] DateTime? busDate)
        {
            ResponseEntity response = new ResponseEntity();

            if (!busDate.HasValue)
            {
                response.success = false;
                response.message = "Parameter busDate wajib diisi.";
                return BadRequest(response);
            }

            var payments = await _paymentAndHistoryService.FilterMonthly(busDate.Value);
            response.success = true;
            response.result = payments;
            return Ok(response);
        }
    }
}
