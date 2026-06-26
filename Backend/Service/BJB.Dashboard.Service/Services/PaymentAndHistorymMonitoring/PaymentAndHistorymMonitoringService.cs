using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.PaymentAndHistorymMonitoring;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Service.Services.PaymentAndHistorymMonitoring;

public class PaymentAndHistorymMonitoringService : IPaymentAndHistorymMonitoringService
{
    private readonly ILogger<PaymentAndHistorymMonitoringService> _logger;
    private readonly IPaymentAndHistorymMonitoringRepository _paymentAndHistorymMonitoringRepository;
    public PaymentAndHistorymMonitoringService(ILogger<PaymentAndHistorymMonitoringService> logger
                                    , IPaymentAndHistorymMonitoringRepository paymentAndHistorymMonitoringRepository)
    {
        _logger = logger;
        _paymentAndHistorymMonitoringRepository = paymentAndHistorymMonitoringRepository;
    }

    public async Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> GetAll()
    {
        return await _paymentAndHistorymMonitoringRepository.GetAll();
    }

    public async Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> FilterDaily(DateTime busDate)
    {
        return await _paymentAndHistorymMonitoringRepository.FilterDaily(busDate);
    }

    public async Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> FilterWeekly(DateTime busDate)
    {
        return await _paymentAndHistorymMonitoringRepository.FilterWeekly(busDate);
    }

    public async Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> FilterMonthly(DateTime busDate)
    {
        return await _paymentAndHistorymMonitoringRepository.FilterMonthly(busDate);
    }
}
