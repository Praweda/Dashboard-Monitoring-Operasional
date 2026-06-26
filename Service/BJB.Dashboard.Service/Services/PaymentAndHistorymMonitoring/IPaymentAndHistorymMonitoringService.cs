using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Service.Services.PaymentAndHistorymMonitoring;

public interface IPaymentAndHistorymMonitoringService
{
    Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> GetAll();
    Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> FilterDaily(DateTime busDate);
    Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> FilterWeekly(DateTime busDate);
    Task<IEnumerable<PaymentAndHistorymMonitoringEntity>> FilterMonthly(DateTime busDate);
}
