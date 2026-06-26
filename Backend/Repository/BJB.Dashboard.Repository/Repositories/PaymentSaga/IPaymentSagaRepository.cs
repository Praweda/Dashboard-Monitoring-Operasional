using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Repository.Repositories.PaymentSaga;

public interface IPaymentSagaRepository
{
    Task<IEnumerable<PaymentSagaEntity>> GetAll();
}
