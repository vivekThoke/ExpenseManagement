using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Entities;

namespace ExpenseManagement.Domain.Interfaces
{
    public interface ILeaveRepository
    {
        Task<LeaveRequest?> GetByIdAsync(Guid id);
        Task<List<LeaveRequest>> GetPendingManagerAsync(Guid managerId);
        Task AddAsync(LeaveRequest request);
        Task UpdateAsync(LeaveRequest request);
    }
}
