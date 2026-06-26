using System;
using BJB.Dashboard.Model.Entity;

namespace BJB.Dashboard.Service.Services.PaymentAndHistory;

public interface IPaymentAndHistoryService
{
    Task<IEnumerable<PaymentAndHistoryEntity>> GetAll();
    Task<IEnumerable<PaymentAndHistoryEntity>> FilterDaily(DateTime busDate);
    Task<IEnumerable<PaymentAndHistoryEntity>> FilterWeekly(DateTime busDate);
    Task<IEnumerable<PaymentAndHistoryEntity>> FilterMonthly(DateTime busDate);
}
