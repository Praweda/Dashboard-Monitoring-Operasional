using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Repository.Repositories.PaymentAndHistory;

public class PaymentAndHistoryRepository : IPaymentAndHistoryRepository
{
    private readonly ILogger<PaymentAndHistoryRepository> _logger;
    private readonly IBaseRepository<PaymentAndHistoryEntity> _baseRepository;

    public PaymentAndHistoryRepository(ILogger<PaymentAndHistoryRepository> logger, IBaseRepository<PaymentAndHistoryEntity> baseRepository)
    {
        _logger = logger;
        _baseRepository = baseRepository;
    }
    public async Task<IEnumerable<PaymentAndHistoryEntity>> GetAll()
    {
        return await _baseRepository.GetAll();
    }

    public async Task<IEnumerable<PaymentAndHistoryEntity>> FilterDaily(DateTime busDate)
    {
        var payments = await GetAll();
        return payments.Where(payment => payment.BusDate.HasValue
                                      && payment.BusDate.Value.Date == busDate.Date);
    }

    public async Task<IEnumerable<PaymentAndHistoryEntity>> FilterWeekly(DateTime busDate)
    {
        var payments = await GetAll();
        var startDate = busDate.Date.AddDays(-GetDaysFromMonday(busDate));
        var endDate = startDate.AddDays(7);

        return payments.Where(payment => payment.BusDate.HasValue
                                      && payment.BusDate.Value.Date >= startDate
                                      && payment.BusDate.Value.Date < endDate);
    }

    public async Task<IEnumerable<PaymentAndHistoryEntity>> FilterMonthly(DateTime busDate)
    {
        var payments = await GetAll();
        var startDate = new DateTime(busDate.Year, busDate.Month, 1);
        var endDate = startDate.AddMonths(1);

        return payments.Where(payment => payment.BusDate.HasValue
                                      && payment.BusDate.Value.Date >= startDate
                                      && payment.BusDate.Value.Date < endDate);
    }

    private static int GetDaysFromMonday(DateTime busDate)
    {
        return ((int)busDate.DayOfWeek + 6) % 7;
    }
}
