using Poker.Domain;
using Poker.Repository.Interfaces;

namespace Poker.Repository
{
    public class CartaRepository : BaseRepository<Carta>, ICartaRepository
    {
        public CartaRepository(PokerContext context) : base(context)
        {
        }
    }
}