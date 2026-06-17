using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BJB.Dashboard.Model.Entity;

[Table("HI110IDJA1_PAYMENT_MONITORING", Schema = "dbo")]
public class PaymentMonitoringEntity
{
    public DateTime? BusDate { get; set; }
    public string? IO { get; set; }
    public decimal? TotalAmount { get; set; }
    public int? Volume { get; set; }
}
