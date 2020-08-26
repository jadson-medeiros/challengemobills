using ChallengeMobills.Business.Intefaces;
using ChallengeMobills.Business.Models;
using ChallengeMobills.Data.Context;

namespace ChallengeMobills.Data.Repository
{
    public class RevenueRepository : Repository<Revenue>, IRevenueRepository
    {
        public RevenueRepository(MyDbContext context) : base(context) { }
    }
}