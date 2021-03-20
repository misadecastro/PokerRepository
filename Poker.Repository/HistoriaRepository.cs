using Poker.Domain;
using Poker.Repository.Interfaces;

namespace Poker.Repository
{
    public class HistoriaRepository : BaseRepository<Historia>, IHistoriaRepository
    {
        public HistoriaRepository(PokerContext context) : base(context)
        {
        }
    }
}
