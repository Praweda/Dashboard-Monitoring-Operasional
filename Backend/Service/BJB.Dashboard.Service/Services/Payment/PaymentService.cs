using System;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.Payment;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Service.Services.Payment;

public class PaymentService : IPaymentService
{
    private readonly ILogger<PaymentService> _logger;
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(ILogger<PaymentService> logger, IPaymentRepository paymentRepository)
    {
        _logger = logger;
        _paymentRepository = paymentRepository;
    }

    public async Task<IEnumerable<PaymentEntity>> GetAll()
    {
        return await _paymentRepository.GetAll();
    }
}
