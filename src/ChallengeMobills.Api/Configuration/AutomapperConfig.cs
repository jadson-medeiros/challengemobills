using AutoMapper;
using ChallengeMobills.Api.ViewModels;
using ChallengeMobills.Business.Models;

namespace ChallengeMobills.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Expense, ExpenseViewModel>().ReverseMap();
            CreateMap<Revenue, RevenueViewModel>().ReverseMap();
        }
    }
}