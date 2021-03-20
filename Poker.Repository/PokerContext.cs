using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Poker.Domain;
using Poker.Domain.Identity;

namespace Poker.Repository
{
    public class PokerContext: IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public PokerContext(DbContextOptions<PokerContext> options): base(options)
        {
            
        }
        
        public DbSet<Carta> Cartas {get; set;}
        public DbSet<Voto> Votos {get; set;}
        public DbSet<Historia> Historias {get; set;}
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Notifiable>();
            modelBuilder.Ignore<Notification>();
        }
    }
}