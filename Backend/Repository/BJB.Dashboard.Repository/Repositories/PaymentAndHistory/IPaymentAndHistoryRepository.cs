using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Repository.Repositories.PaymentAndHistory;

public interface IPaymentAndHistoryRepository
{
    Task<IEnumerable<PaymentAndHistoryEntity>> GetAll();
    Task<IEnumerable<PaymentAndHistoryEntity>> FilterDaily(DateTime busDate);
    Task<IEnumerable<PaymentAndHistoryEntity>> FilterWeekly(DateTime busDate);
    Task<IEnumerable<PaymentAndHistoryEntity>> FilterMonthly(DateTime busDate);
}
