using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Service.Services.PaymentMonitoring;

public interface IPaymentMonitoringService
{
    Task<IEnumerable<PaymentMonitoringEntity>> GetAll();
}
