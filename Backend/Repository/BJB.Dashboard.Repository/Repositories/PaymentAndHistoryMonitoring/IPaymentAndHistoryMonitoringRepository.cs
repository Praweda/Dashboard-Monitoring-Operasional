using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Repository.Repositories.PaymentAndHistoryMonitoring;

public interface IPaymentAndHistoryMonitoringRepository
{
    Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> GetAll();
    Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterDaily(DateTime busDate);
    Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterWeekly(DateTime busDate);
    Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterMonthly(DateTime busDate);
}
