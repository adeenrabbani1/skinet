using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    //this class as name implies, takes in the specs 
    //and will check if any specifications needed to be added,
    //and returns the Iqueriable will the all the specs included.
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> specs)
        {
            var query = inputQuery;
            if (specs.Criteria != null)
            {
                query = query.Where(specs.Criteria); //applies criteria if any
            }
            //now we take care of includes.

            query = specs.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }


    }
}