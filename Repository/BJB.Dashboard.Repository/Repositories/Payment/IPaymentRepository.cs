using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Repository.Repositories.Payment;

public interface IPaymentRepository
{
    Task<IEnumerable<PaymentEntity>> GetAll();
}
