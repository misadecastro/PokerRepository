using Poker.Domain;
using Poker.Facade.Interfaces;
using Poker.Repository;
using Poker.Repository.Interfaces;

namespace Poker.Facade
{   
    public class CartaFacade: BaseFacade<Carta, ICartaRepository>, ICartaFacade
    {
        public CartaFacade(ICartaRepository repository) : base(repository)
        {
            
        }        
    }
}