using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BJB.Dashboard.Model.Entity;

[Table("HI110IDJA1_PAYMENTANDHISTORY_MONITORING", Schema = "dbo")]
public class PaymentAndHistoryMonitoringEntity
{
    public DateTime? BusDate { get; set; }
    public string? IO { get; set; }
    public decimal? TotalAmount { get; set; }
    public long? Volume { get; set; }
}
