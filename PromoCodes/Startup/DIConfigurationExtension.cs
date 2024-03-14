using PromoCodes.EntityFramework;
using PromoCodes.Repositories;
using PromoCodes.Services;
using PromoCodes.UnitOfWork;

namespace PromoCodes.Startup;

public static class DiConfigurationExtension
{
    public static IServiceCollection AddDiImplementation(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
        services.AddTransient<IPromoCodeChangeHistoryRepository, PromoCodeChangeHistoryRepository>();
        services.AddTransient<IPromoCodeService, PromoCodeService>();

        return services;
    }
}