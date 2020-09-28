using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T, object>> orderBy { get; }
        Expression<Func<T, object>> orderByDesc { get; }
        int take { get; }
        int skip { get; }
        bool isPagingEnabled { get; }




    }
}