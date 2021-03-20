using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poker.Repository.Interfaces;

namespace Poker.Repository.Configurations
{
    public static class Bootstrapper
    {
        public static IServiceCollection UsePokerRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICartaRepository, CartaRepository>();
            services.AddTransient<IVotoRepository, VotoRepository>();
            services.AddTransient<IHistoriaRepository, HistoriaRepository>();
            services.AddDbContext<PokerContext>(x => x.UseSqlite(configuration.GetConnectionString("DefaultConnection")));


            return services;
        }
    }
}
