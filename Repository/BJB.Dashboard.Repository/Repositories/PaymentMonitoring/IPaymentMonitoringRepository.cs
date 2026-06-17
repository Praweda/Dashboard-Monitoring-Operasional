using System;
using BJB.Dashboard.Model.Entity;
namespace BJB.Dashboard.Repository.Repositories.PaymentMonitoring;

public interface IPaymentMonitoringRepository
{
    Task<IEnumerable<PaymentMonitoringEntity>> GetAll();
}
