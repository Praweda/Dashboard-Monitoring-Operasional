using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Repository.Repositories.PaymentAndHistoryMonitoring;

public class PaymentAndHistoryMonitoringRepository : IPaymentAndHistoryMonitoringRepository
{
    private readonly ILogger<PaymentAndHistoryMonitoringRepository> _logger;
    private readonly IBaseRepository<PaymentAndHistoryMonitoringEntity> _baseRepository;

    public PaymentAndHistoryMonitoringRepository(ILogger<PaymentAndHistoryMonitoringRepository> logger, IBaseRepository<PaymentAndHistoryMonitoringEntity> baseRepository)
    {
        _logger = logger;
        _baseRepository = baseRepository;
    }
    public async Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> GetAll()
    {
        return await _baseRepository.GetAll();
    }

    public async Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterDaily(DateTime busDate)
    {
        var payments = await GetAll();
        return payments.Where(payment => payment.BusDate.HasValue
                                      && payment.BusDate.Value.Date == busDate.Date);
    }

    public async Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterWeekly(DateTime busDate)
    {
        var payments = await GetAll();
        var startDate = busDate.Date.AddDays(-GetDaysFromMonday(busDate));
        var endDate = startDate.AddDays(7);

        return payments.Where(payment => payment.BusDate.HasValue
                                      && payment.BusDate.Value.Date >= startDate
                                      && payment.BusDate.Value.Date < endDate);
    }

    public async Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterMonthly(DateTime busDate)
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
