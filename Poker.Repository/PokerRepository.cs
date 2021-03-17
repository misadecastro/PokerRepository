using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poker.Domain;

namespace Poker.Repository
{
    public class PokerRepository : IPokerRepository
    {
        public PokerContext _context { get; }

        public PokerRepository(PokerContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<Carta[]> GetAllCartaAsync()
        {
            IQueryable<Carta> query = _context.Cartas;
            
            query = query.OrderBy(c => c.Valor);

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await  _context.SaveChangesAsync()) > 0;
        }

        public void UpDate<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}