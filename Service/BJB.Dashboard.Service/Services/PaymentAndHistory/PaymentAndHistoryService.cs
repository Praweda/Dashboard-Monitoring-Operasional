using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.Payment;
using BJB.Dashboard.Repository.Repositories.PaymentAndHistory;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Service.Services.PaymentAndHistory;

public class PaymentAndHistoryService : IPaymentAndHistoryService
{
    private readonly ILogger<PaymentAndHistoryService> _logger;
    private readonly IPaymentAndHistoryRepository _paymentAndHistoryRepository;
    public PaymentAndHistoryService(ILogger<PaymentAndHistoryService> logger
                                    , IPaymentAndHistoryRepository paymentAndHistoryRepository)
    {
        _logger = logger;
        _paymentAndHistoryRepository = paymentAndHistoryRepository;
    }

    public async Task<IEnumerable<PaymentAndHistoryEntity>> GetAll()
    {
        return await _paymentAndHistoryRepository.GetAll();
    }

    public async Task<IEnumerable<PaymentAndHistoryEntity>> FilterDaily(DateTime busDate)
    {
        return await _paymentAndHistoryRepository.FilterDaily(busDate);
    }

    public async Task<IEnumerable<PaymentAndHistoryEntity>> FilterWeekly(DateTime busDate)
    {
        return await _paymentAndHistoryRepository.FilterWeekly(busDate);
    }

    public async Task<IEnumerable<PaymentAndHistoryEntity>> FilterMonthly(DateTime busDate)
    {
        return await _paymentAndHistoryRepository.FilterMonthly(busDate);
    }
}
