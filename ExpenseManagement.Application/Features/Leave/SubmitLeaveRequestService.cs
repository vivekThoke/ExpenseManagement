using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Application.DTOs;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.Interfaces;

namespace ExpenseManagement.Application.Features.Leave
{
    public class SubmitLeaveRequestService
    {
        private readonly ILeaveRepository leaveRepository;
        private readonly ILeaveBalanceRepository leaveBalanceRepository;

        public SubmitLeaveRequestService(ILeaveRepository leaveRepository, ILeaveBalanceRepository leaveBalanceRepository)
        {
            this.leaveRepository = leaveRepository;
            this.leaveBalanceRepository = leaveBalanceRepository;
        }

        public async Task<Guid> ExecuteAsync(SubmitLeaveRequestDto dto)
        {
            var totalDays = (dto.ToDate - dto.FromDate).Days + 1;

            var balance = await leaveBalanceRepository.GetAsync(dto.UserId, dto.LeaveType);

            if (balance == null)
                throw new Exception("Leave balance not found");

            if (balance.RemainingDays < totalDays)
                throw new Exception("Insufficient leave balance");

            var leaveRequest = new LeaveRequest(dto.UserId, dto.LeaveType, dto.FromDate, dto.ToDate, dto.Reason);

            await leaveRepository.AddAsync(leaveRequest);

            return leaveRequest.Id;
        }
    }
}
