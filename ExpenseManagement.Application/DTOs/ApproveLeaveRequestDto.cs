using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Application.DTOs
{
    public class ApproveLeaveRequestDto
    {
        public Guid LeaveRequestId { get; set; }
        public bool Approve { get; set; }
    }
}
