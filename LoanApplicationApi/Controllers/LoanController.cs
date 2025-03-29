using LoanApplicationApi.Models;
using LoanApplicationApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplicationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        // POST: api/loan
        [HttpPost]
        public async Task<IActionResult> ApplyForLoan([FromBody] LoanApplication loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loanResult = await _loanService.ApplyLoanAsync(loan);
            return Ok(new { message = "Loan application submitted successfully", loan = loanResult });
        }

        // PUT: api/loan/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoanStatus(int id, [FromBody] string status)
        {
            var loan = await _loanService.UpdateLoanStatusAsync(id, status);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        // GET: api/loan
        [HttpGet]
        public async Task<IActionResult> GetLoans()
        {
            var loans = await _loanService.GetAllLoansAsync();
            return Ok(loans);
        }
    }
}
