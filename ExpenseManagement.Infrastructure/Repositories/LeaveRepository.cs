using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.Interfaces;
using ExpenseManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ExpenseManagement.Infrastructure.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly ApplicationDbContext dbContext;

        public LeaveRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<LeaveRequest?> GetByIdAsync(Guid id)
        {
            return await dbContext.LeaveRequests.FindAsync(id);
        }

        public async Task<List<LeaveRequest>> GetPendingManagerAsync(Guid managerId)
        {
            var employeeIds = await dbContext.Users
                                            .Where(u => u.ManagerId == managerId)
                                            .Select(u => u.Id)
                                            .ToListAsync();

            return await dbContext.LeaveRequests
                                .Where(l => employeeIds.Contains(l.UserId) && l.Status == Domain.Enums.LeaveStatus.Pending)
                                .ToListAsync();
        }

        public async Task AddAsync(LeaveRequest request)
        {
            await dbContext.LeaveRequests.AddAsync(request);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(LeaveRequest request)
        {
            dbContext.LeaveRequests.Update(request);
            await dbContext.SaveChangesAsync();
        }
    }
}
