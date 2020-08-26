using System;
using System.Threading.Tasks;
using ChallengeMobills.Business.Models;

namespace ChallengeMobills.Business.Intefaces
{
    public interface IRevenueService : IDisposable
    {
        Task<bool> Insert(Revenue revenue);
        Task<bool> Update(Revenue revenue);
        Task<bool> Delete(Guid id);
    }
}