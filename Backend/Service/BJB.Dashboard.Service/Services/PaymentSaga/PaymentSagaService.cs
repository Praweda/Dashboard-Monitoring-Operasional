using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.PaymentSaga;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Service.Services.PaymentSaga;

public class PaymentSagaService : IPaymentSagaService
{
    private readonly ILogger<PaymentSagaService> _logger;
    private readonly IPaymentSagaRepository _paymentSagaRepository;

    public PaymentSagaService(ILogger<PaymentSagaService> logger, IPaymentSagaRepository paymentSagaRepository)
    {
        _logger = logger;
        _paymentSagaRepository = paymentSagaRepository;
    }

    public async Task<IEnumerable<PaymentSagaEntity>> GetAll()
    {
        return await _paymentSagaRepository.GetAll();
    }
}
