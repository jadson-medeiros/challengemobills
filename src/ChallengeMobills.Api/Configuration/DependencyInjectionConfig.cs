//using ChallengeMobills.Api.Extensions;
using ChallengeMobills.Api.Extensions;
using ChallengeMobills.Business.Intefaces;
using ChallengeMobills.Business.Notifications;
using ChallengeMobills.Business.Services;
using ChallengeMobills.Data.Context;
using ChallengeMobills.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
//using Swashbuckle.AspNetCore.SwaggerGen;

namespace ChallengeMobills.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();

            // Repository
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IRevenueRepository, RevenueRepository>();

            // Services
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IRevenueService, RevenueService>();

            // Notification
            services.AddScoped<INotify, Notify>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}