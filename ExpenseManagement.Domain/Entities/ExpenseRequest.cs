using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Enums;

namespace ExpenseManagement.Domain.Entities
{
    public class ExpenseRequest
    {
        public Guid Id { get; private set; }
        public string EmployeeId { get; private set; } = default!;
        public decimal Amount { get; private set; }
        public string Description { get; private set; } = default!;
        public string Category { get; private set; } = default!;
        public ExpenseStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private ExpenseRequest() { }

        public ExpenseRequest(string employeeId, decimal amount, string description, string category)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            Id = Guid.NewGuid();
            EmployeeId = employeeId;
            Amount = amount;
            Description = description;
            Category = category;
            Status = ExpenseStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void Approve()
        {
            if (Status != ExpenseStatus.Pending)
                throw new InvalidOperationException("Only pending request can be approved");

            Status = ExpenseStatus.Approved;
        }

        public void Reject()
        {
            if (Status != ExpenseStatus.Pending)
                throw new InvalidOperationException("Only pending request can be rejected");

            Status = ExpenseStatus.Rejected;
        }
    }
}
