using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Service.Services.Payment;

public interface IPaymentService
{
    Task<IEnumerable<PaymentEntity>> GetAll();
}
