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
            modelBuilder.Entity<UserRole>(userRole => 
            {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});
                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
                userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });            

            modelBuilder.Entity<Historia>()
            .HasMany(c => c.Votos)
            .WithOne(e => e.Historia);

            modelBuilder.Entity<User>()
            .HasMany(c => c.Votos)
            .WithOne(e => e.Usuario);

            modelBuilder.Entity<Voto>(votoRole => 
            {
                votoRole.HasOne(c => c.Historia)
                .WithMany(e => e.Votos)
                .IsRequired();
                votoRole.HasOne(c => c.Usuario)
                .WithMany(e => e.Votos)
                .IsRequired();
            });
            
        }
    }
}