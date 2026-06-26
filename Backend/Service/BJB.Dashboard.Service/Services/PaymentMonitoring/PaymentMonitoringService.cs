using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.PaymentMonitoring;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Service.Services.PaymentMonitoring;

public class PaymentMonitoringService : IPaymentMonitoringService
{
    private readonly ILogger<PaymentMonitoringService> _logger;
    private readonly IPaymentMonitoringRepository _paymentMonitoringRepository;

    public PaymentMonitoringService(ILogger<PaymentMonitoringService> logger, IPaymentMonitoringRepository paymentMonitoringRepository)
    {
        _logger = logger;
        _paymentMonitoringRepository = paymentMonitoringRepository;
    }

    public async Task<IEnumerable<PaymentMonitoringEntity>> GetAll()
    {
        return await _paymentMonitoringRepository.GetAll();
    }
}
