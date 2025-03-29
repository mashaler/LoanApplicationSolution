using LoanApplicationApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationApi.Services
{
    public interface ILoanService
    {
        Task<List<LoanApplication>> GetAllLoansAsync();
        Task<LoanApplication> ApplyLoanAsync(LoanApplication loan);
        Task<LoanApplication> UpdateLoanStatusAsync(int id, string status);
    }
}
