using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poker.Facade.Configurations;
using Poker.Repository.Configurations;

namespace Poker.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectDependenciesPoker(this IServiceCollection services, IConfiguration configuration)
        {
            services.UsePokerFacade(configuration);
            services.UsePokerRepository(configuration);

            return services;
        }
    }
}
