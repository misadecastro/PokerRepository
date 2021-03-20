using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poker.Facade.Interfaces;

namespace Poker.Facade.Configurations
{
    public static class Bootstrapper
    {
        public static IServiceCollection UsePokerFacade(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICartaFacade, CartaFacade>();
            services.AddTransient<IVotoFacade, VotoFacade>();
            services.AddTransient<IHistoriaFacade, HistoriaFacade>();

            return services;
        }
    }
}