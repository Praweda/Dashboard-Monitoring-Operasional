using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Repository.Repositories.PaymentSaga;

public class PaymentSagaRepository : IPaymentSagaRepository
{
    private readonly ILogger<PaymentSagaRepository> _logger;
    private readonly IBaseRepository<PaymentSagaEntity> _baseRepository;

    public PaymentSagaRepository(ILogger<PaymentSagaRepository> logger, IBaseRepository<PaymentSagaEntity> baseRepository)
    {
        _logger = logger;
        _baseRepository = baseRepository;
    }
    public async Task<IEnumerable<PaymentSagaEntity>> GetAll()
    {
        return await _baseRepository.GetAll();
    }
}
