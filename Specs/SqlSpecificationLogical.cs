using System.Linq.Expressions;
using Ancelotow.DbCore.Performance.Specs.Factories;
using Microsoft.EntityFrameworkCore;

namespace Ancelotow.DbCore.Performance.Specs;

internal abstract class SqlSpecificationLogical<T> : ISqlSpecification<T>
{
    public static SqlSpecificationLogical<T> All => SqlSpecificationFactory.All<T>();

    public abstract Expression<Func<T, bool>> ToExpression();

    public ISqlSpecification<T> And(ISqlSpecification<T> other)
    {
        return new AndSqlSpecification<T>(this, other);
    }

    public ISqlSpecification<T> Or(ISqlSpecification<T> other)
    {
        return new OrSqlSpecification<T>(this, other);
    }

    public ISqlSpecification<T> Not()
    {
        return new NotSqlSpecification<T>(this);
    }
}