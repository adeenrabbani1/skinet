using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        //generic methods implementation, where T will be decided at runtime
        //saves us from writing multiple methods that actually do the same task.
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetEntityBySpec(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }
        //for getting the count of the items that matched the filters.
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }


        //helper method that applies criteria and includes and
        //return back the queryable query which then can be executed.
        private IQueryable<T> ApplySpecifications(ISpecification<T> specs)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specs);
        }


    }
}