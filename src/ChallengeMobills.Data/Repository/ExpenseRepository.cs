using ChallengeMobills.Business.Intefaces;
using ChallengeMobills.Business.Models;
using ChallengeMobills.Data.Context;

namespace ChallengeMobills.Data.Repository
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(MyDbContext context) : base(context)
        {
        }
    }
}