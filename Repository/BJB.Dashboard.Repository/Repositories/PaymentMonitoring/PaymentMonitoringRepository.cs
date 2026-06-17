using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Repository.Repositories.PaymentMonitoring;

public class PaymentMonitoringRepository : IPaymentMonitoringRepository
{
    private readonly ILogger<PaymentMonitoringRepository> _logger;
    private readonly IBaseRepository<PaymentMonitoringEntity> _baseRepository;

    public PaymentMonitoringRepository(ILogger<PaymentMonitoringRepository> logger, IBaseRepository<PaymentMonitoringEntity> baseRepository)
    {
        _logger = logger;
        _baseRepository = baseRepository;
    }
    public async Task<IEnumerable<PaymentMonitoringEntity>> GetAll()
    {
        return await _baseRepository.GetAll();
    }
}
