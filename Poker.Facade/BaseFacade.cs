using Poker.Domain;
using Poker.Facade.Interfaces;
using Poker.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poker.Facade
{
    public abstract class BaseFacade<T, TRepository> : IBaseFacade<T> where T : BaseEntity
        where TRepository : IBaseRepository<T>
    {
        protected readonly TRepository _repository;

        public BaseFacade(TRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            var model = _repository.GetAsync(id).Result;
            _repository.Delete(model);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var model = await _repository.GetAsync(entity.ID);

            if (model == null)
                throw new System.Exception("Registro não encontrado");

            _repository.UpDate(model);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            _repository.Add(entity);
            return await _repository.SaveChangesAsync();
        }
    }
}