using NExpenseTracker.Api.Enums;

namespace NExpenseTracker.Api.Entities
{
    public class TransactionEntity
    {
        public Guid Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public double Value { get; set; }
        public Recurrence Recurrence = Recurrence.NoRecurrence;
        public required InvoiceEntity Invoice { get; set; }
        public Guid InvoiceId { get; set; }
    }
}
