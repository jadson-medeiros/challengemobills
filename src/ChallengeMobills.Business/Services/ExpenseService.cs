using System;
using System.Linq;
using System.Threading.Tasks;
using ChallengeMobills.Business.Intefaces;
using ChallengeMobills.Business.Models;
using ChallengeMobills.Business.Models.Validations;

namespace ChallengeMobills.Business.Services
{
    public class ExpenseService : BaseService, IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository,
            INotify notify) : base(notify)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<bool> Insert(Expense expense)
        {
            await _expenseRepository.Insert(expense);
            return true;
        }

        public async Task<bool> Update(Expense expense)
        {
            if (!ExecuteValidation(new ExpenseValidation(), expense)) return false;

            if (_expenseRepository.Search(f => f.Id != expense.Id).Result.Any())
            {
                Inform("Expense duplicated.");
                return false;
            }

            await _expenseRepository.Update(expense);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _expenseRepository.Delete(id);
            return true;
        }

        public void Dispose()
        {
            _expenseRepository?.Dispose();
        }
    }
}