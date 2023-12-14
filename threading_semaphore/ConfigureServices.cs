using threading_semaphore.Interfaces;
using threading_semaphore.Queues;
using threading_semaphore.Services;

namespace threading_semaphore
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRedeemVoucherService, RedeemVoucherService>();
            services.AddSingleton<IRedeemVoucherSemaphore, RedeemVoucherSemaphore>();

            return services;
        }
    }
}
