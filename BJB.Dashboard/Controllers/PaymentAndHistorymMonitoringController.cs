using BJB.Dashboard.Library.Message.Response;
using BJB.Dashboard.Service.Services.PaymentAndHistorymMonitoring;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BJB.Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentAndHistorymMonitoringController : ControllerBase
    {
        private readonly ILogger<PaymentAndHistorymMonitoringController> _logger;
        private readonly IPaymentAndHistorymMonitoringService _paymentAndHistorymMonitoringService;

        public PaymentAndHistorymMonitoringController(ILogger<PaymentAndHistorymMonitoringController> logger
                                            , IPaymentAndHistorymMonitoringService paymentAndHistorymMonitoringService)
        {
            _logger = logger;
            _paymentAndHistorymMonitoringService = paymentAndHistorymMonitoringService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ResponseEntity response = new ResponseEntity();

            var payments = await _paymentAndHistorymMonitoringService.GetAll();
            response.success = true;
            response.result = payments;
            return Ok(response);
        }

        [HttpGet("FilterDaily")]
        public async Task<IActionResult> FilterDaily([FromQuery] string? busDate)
        {
            if (!TryParseBusDate(busDate, out var parsedBusDate, out var errorResponse))
            {
                return BadRequest(errorResponse);
            }

            ResponseEntity response = new ResponseEntity();
            var payments = await _paymentAndHistorymMonitoringService.FilterDaily(parsedBusDate);
            response.success = true;
            response.result = payments;
            return Ok(response);
        }

        [HttpGet("FilterWeekly")]
        public async Task<IActionResult> FilterWeekly([FromQuery] string? busDate)
        {
            if (!TryParseBusDate(busDate, out var parsedBusDate, out var errorResponse))
            {
                return BadRequest(errorResponse);
            }

            ResponseEntity response = new ResponseEntity();
            var payments = await _paymentAndHistorymMonitoringService.FilterWeekly(parsedBusDate);
            response.success = true;
            response.result = payments;
            return Ok(response);
        }

        [HttpGet("FilterMonthly")]
        public async Task<IActionResult> FilterMonthly([FromQuery] string? busDate)
        {
            if (!TryParseBusDate(busDate, out var parsedBusDate, out var errorResponse))
            {
                return BadRequest(errorResponse);
            }

            ResponseEntity response = new ResponseEntity();
            var payments = await _paymentAndHistorymMonitoringService.FilterMonthly(parsedBusDate);
            response.success = true;
            response.result = payments;
            return Ok(response);
        }

        private static bool TryParseBusDate(string? busDate, out DateTime parsedBusDate, out ResponseEntity errorResponse)
        {
            parsedBusDate = default;
            errorResponse = new ResponseEntity();

            if (string.IsNullOrWhiteSpace(busDate))
            {
                errorResponse.success = false;
                errorResponse.message = "Parameter busDate wajib diisi.";
                return false;
            }

            if (!DateTime.TryParseExact(busDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedBusDate))
            {
                errorResponse.success = false;
                errorResponse.message = "Format busDate harus yyyy-MM-dd.";
                return false;
            }

            return true;
        }
    }
}
