using Poker.Domain;
using Poker.Repository.Interfaces;

namespace Poker.Repository
{
    class VotoRepository : BaseRepository<Voto>, IVotoRepository
    {
        public VotoRepository(PokerContext context) : base(context)
        {
            
        }        
    }
}
