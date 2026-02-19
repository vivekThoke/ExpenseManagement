using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Enums;

namespace ExpenseManagement.Domain.Entities
{
    public class DecisionLog
    {
        public Guid Id { get; private set; }
        public Guid LeaveRequestId { get; private set; }
        public int PolicyScore { get; private set; }
        public int PatternScore { get; private set; }
        public int AiScore { get; private set; }
        public int FinalRiskScore { get; private set; }
        public LeaveStatus ManagerDecision { get; private set; }
        public string? OverrideReason { get; private set; }
        public DateTime DecidedAt { get; private set; }

        private DecisionLog() { }

        public DecisionLog(Guid leaveRequestId, 
            int policyScore, 
            int patternScore, 
            int aiScore, 
            int finalRiskScore, 
            LeaveStatus managerDecision, 
            string? overrideReason = null)
        {
            Id = Guid.NewGuid();
            LeaveRequestId = leaveRequestId;
            PolicyScore = policyScore;
            PatternScore = patternScore;
            AiScore = aiScore;
            FinalRiskScore = finalRiskScore;
            ManagerDecision = managerDecision;
            OverrideReason = overrideReason;
            DecidedAt = DateTime.UtcNow;
        }
    }
}
