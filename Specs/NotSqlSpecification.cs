using System.Linq.Expressions;

namespace Ancelotow.SqlSpecification.Specs;

/// <summary>
/// NOT SQL Specification
/// </summary>
/// <typeparam name="T">Data layer object</typeparam>
internal class NotSqlSpecification<T>(
    ISqlSpecification<T> original
) : ISqlSpecification<T>
{
    public Expression<Func<T, bool>> ToExpression()
    {
        var originalExpression = original.ToExpression();
        var parameter = Expression.Parameter(typeof(T));
        var originalBody = Expression.Invoke(originalExpression, parameter);
        var body = Expression.Negate(originalBody);
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }

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