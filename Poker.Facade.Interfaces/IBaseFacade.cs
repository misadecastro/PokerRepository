using Poker.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poker.Facade.Interfaces
{
    public interface IBaseFacade<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> UpdateAsync(T entity);
        Task<bool> CreateAsync(T entity);
        void Delete(int id);
        Task<T> GetAsync(int id);
    }
}