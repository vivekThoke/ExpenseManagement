using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Application.DTOs;
using ExpenseManagement.Domain.Enums;
using ExpenseManagement.Domain.Interfaces;

namespace ExpenseManagement.Application.Features.Leave
{
    public class ApproveLeaveRequestService
    {
        private readonly ILeaveRepository leaveRepository;
        private readonly ILeaveBalanceRepository leaveBalanceRepository;

        public ApproveLeaveRequestService(ILeaveRepository leaveRepository, ILeaveBalanceRepository leaveBalanceRepository)
        {
            this.leaveRepository = leaveRepository;
            this.leaveBalanceRepository = leaveBalanceRepository;
        }

        public async Task ExecuteAsync(ApproveLeaveRequestDto dto)
        {
            var leave = await leaveRepository.GetByIdAsync(dto.LeaveRequestId);

            if (leave == null)
                throw new Exception("Leave request not found");

            if (leave.Status != LeaveStatus.Pending)
                throw new Exception("Only pending request can be processed.");

            if (dto.Approve)
            {
                var totalDays = (leave.ToDate - leave.FromDate).Days + 1;

                var balance = await leaveBalanceRepository.GetAsync(leave.UserId, leave.LeaveType);

                if (balance == null)
                    throw new Exception("Leave balance not found");

                balance.DeductDays(totalDays);

                leave.Approve();

                await leaveBalanceRepository.UpdateAsync(balance);
            }
            else
            {
                leave.Reject();
            }

            await leaveRepository.UpdateAsync(leave);
        }
    }
}
