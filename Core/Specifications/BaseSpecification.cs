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

        public Expression<Func<T, object>> orderBy { get; private set; }

        public Expression<Func<T, object>> orderByDesc { get; private set; }

        public int take { get; private set; }

        public int skip { get; private set; }

        public bool isPagingEnabled { get; private set; }

        //helper method to help us include as many includes as we want.
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        //method to add orderby specs
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            this.orderBy = orderByExpression;
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            this.orderByDesc = orderByDescExpression;
        }
        protected void AddPagination(int skip, int take)
        {
            this.take = take;
            this.skip = skip;
            this.isPagingEnabled = true;

        }
    }
}