using System;

namespace ChallengeMobills.Business.Models
{
    public class Revenue : Entity
    {
        public string Description { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public bool WasReceived { get; set; }
    }
}