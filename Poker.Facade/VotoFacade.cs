
using Poker.Domain;
using Poker.Domain.Identity;
using Poker.Facade.Interfaces;
using Poker.Repository.Interfaces;
using System.Threading.Tasks;

namespace Poker.Facade
{
    class VotoFacade : BaseFacade<Voto, IVotoRepository>, IVotoFacade
    {
        private readonly ICartaRepository _cartaRepository;
        private readonly IHistoriaRepository _historiaRepository;
        public VotoFacade(IVotoRepository repository, ICartaRepository cartaRepository, IHistoriaRepository historiaRepository) : base(repository)
        {
            this._cartaRepository = cartaRepository;
            this._historiaRepository = historiaRepository;
        }

        public async Task<Voto> Votar(Carta carta, Historia historia, User user)
        {
            carta = await _cartaRepository.GetAsync(carta.ID);
            historia = await _historiaRepository.GetAsync(historia.ID, true);
            var voto = new Voto(user, carta, historia);

            if (!voto.Invalid)
            {
                _repository.Add(voto);
                await _repository.SaveChangesAsync();
            }

            return voto;
                
        }
    }
}
