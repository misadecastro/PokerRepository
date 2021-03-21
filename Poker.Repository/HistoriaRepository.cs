using Microsoft.EntityFrameworkCore;
using Poker.Domain;
using Poker.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Repository
{
    public class HistoriaRepository : BaseRepository<Historia>, IHistoriaRepository
    {
        public HistoriaRepository(PokerContext context) : base(context)
        {
        }
        public async Task<Historia> GetAsync(int id, bool incluirVotos)
        {
            IQueryable<Historia> query = _context.Historias.Where(h => h.ID.Equals(id));
            

            if (incluirVotos)
                query = query.Include(c => c.Votos);

            return await query.FirstOrDefaultAsync();
        }
    }
}
