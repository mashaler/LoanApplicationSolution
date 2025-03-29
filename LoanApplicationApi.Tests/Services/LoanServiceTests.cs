using LoanApplicationApi.Models;
using LoanApplicationApi.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LoanApplicationApi.Tests.Services
{
    public class LoanServiceTests
    {
        private readonly LoanService _service;

        public LoanServiceTests()
        {
            _service = new LoanService();
        }

        [Fact]
        public async Task ApplyLoan_ReturnsLoanWithId()
        {
            // Arrange
            var loan = new LoanApplication { Name = "Jane Doe", Amount = 5000, Duration = 24 };

            // Act
            var result = await _service.ApplyLoanAsync(loan);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Jane Doe", result.Name);
        }

        [Fact]
        public async Task UpdateLoanStatus_ReturnsUpdatedLoan_WhenLoanIsFound()
        {
            // Arrange
            var loan = new LoanApplication { Name = "John Doe", Amount = 5000, Duration = 12 };
            var appliedLoan = await _service.ApplyLoanAsync(loan);
            var updatedLoan = await _service.UpdateLoanStatusAsync(appliedLoan.Id, "Approved");

            // Act
            var result = await _service.UpdateLoanStatusAsync(appliedLoan.Id, "Approved");

            // Assert
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.Equal("Approved", result.Status);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
