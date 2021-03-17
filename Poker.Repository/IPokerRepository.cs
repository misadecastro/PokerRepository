using System.Threading.Tasks;
using Poker.Domain;

namespace Poker.Repository
{
    public interface IPokerRepository
    {
        void Add<T>(T entity) where T : class;
		void UpDate<T>(T entity) where T : class;
		void DeleteRange<T>(T[] entityArray) where T : class;
		void Delete<T>(T entity) where T : class;
		Task<bool> SaveChangesAsync();

		#region Carta
		Task<Carta[]> GetAllCartaAsync();
		#endregion
    }
}