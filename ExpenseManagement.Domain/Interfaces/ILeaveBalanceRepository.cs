using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.Enums;

namespace ExpenseManagement.Domain.Interfaces
{
    
    public interface ILeaveBalanceRepository
    {
        Task<LeaveBalance?> GetAsync(Guid userId, LeaveType leaveType);
        Task UpdateAsync(LeaveBalance leaveBalance);
    }
}
