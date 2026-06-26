using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Repository.Repositories.PaymentAndHistorymMonitoring;

public interface IPaymentAndHistorymMonitoringRepository
{
    Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> GetAll();
    Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> FilterDaily(DateTime busDate);
    Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> FilterWeekly(DateTime busDate);
    Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> FilterMonthly(DateTime busDate);
}
