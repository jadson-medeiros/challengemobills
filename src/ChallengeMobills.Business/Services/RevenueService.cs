using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeMobills.Business.Intefaces;
using ChallengeMobills.Business.Models;
using ChallengeMobills.Business.Models.Validations;

namespace ChallengeMobills.Business.Services
{
    public class RevenueService : BaseService, IRevenueService
    {
        private readonly IRevenueRepository _revenueRepository;

        public RevenueService(IRevenueRepository revenueRepository,
            INotify notify) : base(notify)
        {
            _revenueRepository = revenueRepository;
        }

        public async Task<bool> Insert(Revenue revenue)
        {
            await _revenueRepository.Insert(revenue);
            return true;
        }

        public async Task<bool> Update(Revenue revenue)
        {
            if (!ExecuteValidation(new RevenueValidation(), revenue)) return false;

            if (_revenueRepository.Search(f => f.Id != revenue.Id).Result.Any())
            {
                Inform("Expense duplicated.");
                return false;
            }

            await _revenueRepository.Update(revenue);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _revenueRepository.Delete(id);
            return true;
        }

        public async Task<decimal> GetBalance(IEnumerable<Revenue> revenues)
        {
            decimal balance = 0;
            if (revenues == null) return balance;
            if (revenues.Count() == 0) return balance;

            foreach (var item in revenues.Select(o => o.Value)) balance += item;
            return balance;
        }

        public void Dispose()
        {
            _revenueRepository?.Dispose();
        }
    }
}