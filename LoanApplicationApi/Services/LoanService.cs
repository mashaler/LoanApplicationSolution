using LoanApplicationApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplicationApi.Services
{
    public class LoanService : ILoanService
    {
        private static List<LoanApplication> _loanApplications = new List<LoanApplication>();

        public async Task<List<LoanApplication>> GetAllLoansAsync()
        {
            // Simulating asynchronous database operation
            return await Task.FromResult(_loanApplications);
        }

        public async Task<LoanApplication> ApplyLoanAsync(LoanApplication loan)
        {
            loan.Id = _loanApplications.Count + 1;  // Simulate ID generation
            _loanApplications.Add(loan);
            return await Task.FromResult(loan);
        }

        public async Task<LoanApplication> UpdateLoanStatusAsync(int id, string status)
        {
            var loan = _loanApplications.FirstOrDefault(l => l.Id == id);
            if (loan != null)
            {
                loan.Status = status;
                return await Task.FromResult(loan);
            }
            return null;
        }
    }
}
