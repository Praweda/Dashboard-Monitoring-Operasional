using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Service.Services.PaymentSaga;

public interface IPaymentSagaService
{
    Task<IEnumerable<PaymentSagaEntity>> GetAll();
}
