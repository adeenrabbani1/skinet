using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
//a generic repository which will save us from writing very simmillar fucntions
//that do simmillar tasks
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id); //T will be determine at the runtime.
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityBySpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec); //getting count of the elements that matched the filter.


    }
}