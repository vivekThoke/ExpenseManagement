using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Domain.Entities
{
    public class AuditLog
    {
        public Guid Id { get; private set; }
        public Guid ExpenseRequestId { get; private set; }
        public string ChangedBy { get; private set; } = default!;
        public string OldStatus { get; private set; } = default!;
        public string NewStatus { get; private set; } = default!;
        public DateTime ChangedAt { get; private set; }

        private AuditLog() { }

        public AuditLog(Guid expenseRequestId, string changedBy, string oldStatus, string newStatus)
        {
            Id = Guid.NewGuid();
            ExpenseRequestId = expenseRequestId;
            ChangedBy = changedBy;
            OldStatus = oldStatus;
            NewStatus = newStatus;
            ChangedAt = DateTime.Now;
        }

    }
}
