using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BJB.Dashboard.Model.Entity;

[Table("PaymentSaga", Schema = "dbo")]
public class PaymentSagaEntity
{
    [Key]
    public Guid PaymentSagaId { get; set; }
    public string? Trn { get; set; }
    public string? ProcessState { get; set; }
    public string? PublishState { get; set; }
    public DateTime? DateStamp { get; set; }
    public string? SagaType { get; set; }
    public string? Source { get; set; }
    public string? Reason { get; set; }
    public DateTime? Sttltime { get; set; }
}
