using Poker.Domain;
using Poker.Facade.Interfaces;
using Poker.Repository.Interfaces;

namespace Poker.Facade
{
    class HistoriaFacade : BaseFacade<Historia, IHistoriaRepository>, IHistoriaFacade
    {
        public HistoriaFacade(IHistoriaRepository repository) : base(repository)
        {

        }
    }
}
