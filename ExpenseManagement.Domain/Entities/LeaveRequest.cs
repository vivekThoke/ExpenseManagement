using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Enums;

namespace ExpenseManagement.Domain.Entities
{
    public class LeaveRequest
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public LeaveType LeaveType { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public string Reason { get; private set; } = default!;
        public LeaveStatus Status { get; private set; }
        public int? RiskScore { get; private set; }
        public string? AiSummary { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private LeaveRequest() { }

        public LeaveRequest(Guid userId, LeaveType leaveType, DateTime formDate, DateTime toDate, string reason)
        {
            if (toDate < formDate)
            {
                throw new ArgumentException("To-Date cannot be earlier than Form-Date");
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentException("Reason is required");
            }

            Id = Guid.NewGuid();
            UserId = userId;
            LeaveType = leaveType;
            FromDate = formDate;
            ToDate = toDate;
            Reason = reason;
            AiSummary = string.Empty;
            Status = LeaveStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void Approve()
        {
            if(Status != LeaveStatus.Pending)
            {
                throw new InvalidOperationException("Only pending requests can be approved");
            }

            Status = LeaveStatus.Approved;
        }

        public void Reject()
        {
            if (Status != LeaveStatus.Pending)
            {
                throw new InvalidOperationException("Only pending request can be rejected");
            }

            Status = LeaveStatus.Rejected;
        }

        public void SetAiAnalysis(int riskScore, string aiSummary)
        {
            RiskScore = riskScore;
            AiSummary = aiSummary;
        }
    }
}
