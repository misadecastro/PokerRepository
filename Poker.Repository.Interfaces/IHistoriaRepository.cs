using Poker.Domain;
using System.Threading.Tasks;

namespace Poker.Repository.Interfaces
{
    public interface IHistoriaRepository : IBaseRepository<Historia>
    {
        Task<Historia> GetAsync(int id, bool incluirVotos);
    }
}
