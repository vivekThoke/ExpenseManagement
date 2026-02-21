using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.Enums;
using ExpenseManagement.Domain.Interfaces;
using ExpenseManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Infrastructure.Repositories
{
    public class LeaveBalanceRepository : ILeaveBalanceRepository
    {
        private readonly ApplicationDbContext dbContext;

        public LeaveBalanceRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<LeaveBalance?> GetAsync(Guid userId, LeaveType leaveType)
        {
            return await dbContext.LeaveBalances.FirstOrDefaultAsync(lb => lb.UserId == userId && lb.LeaveType == leaveType);
        }


        public async Task UpdateAsync(LeaveBalance leaveBalance)
        {
            dbContext.LeaveBalances.Update(leaveBalance);
            await dbContext.SaveChangesAsync();
        }

    }
}
