using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Repository.Repositories.Payment;

public class PaymentRepository : IPaymentRepository
{
    private readonly ILogger<PaymentRepository> _logger;
    private readonly IBaseRepository<PaymentEntity> _baseRepository;

    public PaymentRepository(ILogger<PaymentRepository> logger, IBaseRepository<PaymentEntity> baseRepository)
    {
        _logger = logger;
        _baseRepository = baseRepository;
    }
    public async Task<IEnumerable<PaymentEntity>> GetAll()
    {
        return await _baseRepository.GetAll();
    }
}