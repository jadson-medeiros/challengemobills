using System;
using System.Threading.Tasks;
using ChallengeMobills.Business.Models;

namespace ChallengeMobills.Business.Intefaces
{
    public interface IExpenseService : IDisposable
    {
        Task<bool> Insert(Expense expense);
        Task<bool> Update(Expense expense);
        Task<bool> Delete(Guid id);
    }
}