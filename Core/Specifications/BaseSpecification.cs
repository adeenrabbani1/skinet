using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;

        }
        public BaseSpecification() { }

        //criteria for the query (eg : p => p.Id == id)
        public Expression<Func<T, bool>> Criteria { get; }

        //will contain all the includes that we want to out query to have.
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        //helper method to help us include as many includes as we want.
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}