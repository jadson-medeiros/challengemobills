using System;

namespace ChallengeMobills.Business.Models
{
    public class Expense : Entity
    {
        public string Description { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public bool IsPaid { get; set; }
    }
}