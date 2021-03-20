using Poker.Domain;
using Poker.Domain.Identity;
using System.Threading.Tasks;

namespace Poker.Facade.Interfaces
{
    public interface IVotoFacade : IBaseFacade<Voto>
    {
        Task<Voto> Votar(Carta carta, Historia historia, User user);
    }
}
