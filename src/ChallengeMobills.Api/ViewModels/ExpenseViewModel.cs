using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeMobills.Api.ViewModels
{
    public class ExpenseViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The 'Value' is required")]
        public decimal Value { get; set; }

        public decimal Balance { get; set; }

        [Required(ErrorMessage = "The 'Date' is required")]
        public DateTime Date { get; set; }

        public bool IsPaid { get; set; }
    }
}
