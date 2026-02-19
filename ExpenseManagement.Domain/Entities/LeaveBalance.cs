using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Enums;

namespace ExpenseManagement.Domain.Entities
{
    public class LeaveBalance
    {
        public Guid UserId { get; private set; }
        public LeaveType LeaveType { get; private set; }
        public int RemainingDays { get; private set; }

        private LeaveBalance() { }

        public LeaveBalance(Guid userId, LeaveType leaveType, int initialDays)
        {
            if (initialDays < 0)
            {
                throw new ArgumentException("Initial days cannot be negative");
            }

            UserId = userId;
            LeaveType = leaveType;
            RemainingDays = initialDays;
        }

        public void DeductDays(int days)
        {
            if (days <= 0)
            {
                throw new ArgumentException("Days must be greater than zero");
            }

            if (RemainingDays < days)
            {
                throw new InvalidOperationException("Insufficient leave balance");
            }

            RemainingDays -= days;
        }

        public void AddDays(int days)
        {
            if (days <= 0)
            {
                throw new ArgumentException("Days must be greater than zero");
            }

            RemainingDays += days;
        }

    }
}
