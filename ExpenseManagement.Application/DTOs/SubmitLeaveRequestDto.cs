using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Enums;

namespace ExpenseManagement.Application.DTOs
{
    public class SubmitLeaveRequestDto
    {
        public Guid UserId { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; } = string.Empty;

    }
}
