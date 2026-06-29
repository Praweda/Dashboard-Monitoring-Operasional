using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.PaymentAndHistoryMonitoring;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Service.Services.PaymentAndHistoryMonitoring;

public class PaymentAndHistoryMonitoringService : IPaymentAndHistoryMonitoringService
{
    private readonly ILogger<PaymentAndHistoryMonitoringService> _logger;
    private readonly IPaymentAndHistoryMonitoringRepository _paymentAndHistoryMonitoringRepository;
    public PaymentAndHistoryMonitoringService(ILogger<PaymentAndHistoryMonitoringService> logger
                                    , IPaymentAndHistoryMonitoringRepository paymentAndHistoryMonitoringRepository)
    {
        _logger = logger;
        _paymentAndHistoryMonitoringRepository = paymentAndHistoryMonitoringRepository;
    }

    public async Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> GetAll()
    {
        return await _paymentAndHistoryMonitoringRepository.GetAll();
    }

    public async Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterDaily(DateTime busDate)
    {
        return await _paymentAndHistoryMonitoringRepository.FilterDaily(busDate);
    }

    public async Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterWeekly(DateTime busDate)
    {
        return await _paymentAndHistoryMonitoringRepository.FilterWeekly(busDate);
    }

    public async Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterMonthly(DateTime busDate)
    {
        return await _paymentAndHistoryMonitoringRepository.FilterMonthly(busDate);
    }
}
