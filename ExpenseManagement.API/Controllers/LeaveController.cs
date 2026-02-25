using ExpenseManagement.Application.DTOs;
using ExpenseManagement.Application.Features.Leave;
using ExpenseManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ExpenseManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : Controller
    {
        private readonly SubmitLeaveRequestService submitService;
        private readonly ApproveLeaveRequestService approveLeaveRequestService;

        public LeaveController(SubmitLeaveRequestService submitService, ApproveLeaveRequestService approveLeaveRequestService)
        {
            this.submitService = submitService;
            this.approveLeaveRequestService = approveLeaveRequestService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit(SubmitLeaveRequestDto dto)
        {
            var id = await submitService.ExecuteAsync(dto);
            return Ok(new { LeaveRequestId = id });
        }

        [HttpPost("process")]
        public async Task<IActionResult> Process(ApproveLeaveRequestDto dto)
        {
            await approveLeaveRequestService.ExecuteAsync(dto);
            return Ok("Leave request approved");
        }
    }
}
