using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Shared
{
    /*
    Implementação baseada na solução proposta por Adler Pagliarini
     em https://medium.com/@adlerpagliarini/c-net-core-criando-uma-aplica%C3%A7%C3%A3o-utilizando-repository-pattern-com-dois-orms-diferentes-dapper-bf5373206ac
     Acesso dia 17/03/2020   
     */
    public interface IRepositoryAsync<T> : IDisposable where T : class, IIdentityEntity
    {
        Task<int> AddAsync(T entity);
        Task<int> AddRangeAsync(IEnumerable<T> entities);

        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllByIdAsync(object id);

        Task<int> UpdateAsync(T obj);
        Task<int> UpdateRangeAsync(IEnumerable<T> entities);

        Task<bool> RemoveAsync(object id);
        Task<int> RemoveAsync(T obj);
        Task<int> RemoveRangeAsync(IEnumerable<T> entities);
    }
}
