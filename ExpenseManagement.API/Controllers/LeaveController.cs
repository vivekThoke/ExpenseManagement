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

        public LeaveController(SubmitLeaveRequestService submitService)
        {
            this.submitService = submitService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit(SubmitLeaveRequestDto dto)
        {
            var id = await submitService.ExecuteAsync(dto);
            return Ok(new { LeaveRequestId = id });
        }
    }
}
