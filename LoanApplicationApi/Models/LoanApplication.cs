using System.ComponentModel.DataAnnotations;

namespace LoanApplicationApi.Models
{
    public class LoanApplication
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 100000)]
        public double Amount { get; set; }

        [Range(1, 60)]
        public int Duration { get; set; }

        public string Status { get; set; } = "Pending"; // Default value
    }
}
