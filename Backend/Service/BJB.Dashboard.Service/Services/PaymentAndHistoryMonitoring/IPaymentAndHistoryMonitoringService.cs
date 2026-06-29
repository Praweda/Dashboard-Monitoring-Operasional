using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Service.Services.PaymentAndHistoryMonitoring;

public interface IPaymentAndHistoryMonitoringService
{
    Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> GetAll();
    Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterDaily(DateTime busDate);
    Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterWeekly(DateTime busDate);
    Task<IEnumerable<PaymentAndHistoryMonitoringEntity>> FilterMonthly(DateTime busDate);
}
