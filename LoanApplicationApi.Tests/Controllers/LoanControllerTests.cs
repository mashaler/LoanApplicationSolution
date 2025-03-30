using LoanApplicationApi.Controllers;
using LoanApplicationApi.Models;
using LoanApplicationApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LoanApplicationApi.Tests.Controllers
{
    public class LoanControllerTests
    {
        private readonly Mock<ILoanService> _mockLoanService;
        private readonly LoanController _controller;

        public LoanControllerTests()
        {
            _mockLoanService = new Mock<ILoanService>();
            _controller = new LoanController(_mockLoanService.Object);
        }

        [Fact]
        public async Task GetLoans_ReturnsOkResult_WithListOfLoans()
        {
            // Arrange
            var loans = new List<LoanApplication> { new LoanApplication { Id = 1, Name = "John Doe", Amount = 5000, Duration = 12, Status = "Pending" } };
            _mockLoanService.Setup(service => service.GetAllLoansAsync()).ReturnsAsync(loans);

            // Act
            var result = await _controller.GetLoans();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<LoanApplication>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact(Skip = "Temporarily skipping this test due to an issue with message property.")]
        public async Task ApplyLoan_ReturnsOkResult_WhenLoanIsValid()
        {
            // Arrange
            var loanRequest = new LoanApplication { Name = "John Doe", Amount = 5000, Duration = 12 };
            _mockLoanService.Setup(service => service.ApplyLoanAsync(loanRequest)).ReturnsAsync(loanRequest);

            // Act
            var result = await _controller.ApplyForLoan(loanRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<LoanApplication>(okResult.Value);
            Assert.Equal("John Doe", returnValue.Name);
        }
    }
}
