using System.Linq.Expressions;

namespace Ancelotow.SqlSpecification.Specs;

/// <summary>
/// OR SQL Specification
/// </summary>
/// <param name="left">Left specification</param>
/// <param name="right">Right specification</param>
/// <typeparam name="T">Data layer object</typeparam>
internal class OrSqlSpecification<T>(
    ISqlSpecification<T> left, 
    ISqlSpecification<T> right
) : ISqlSpecification<T>
{
    public Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = left.ToExpression();
        var rightExpression = right.ToExpression();
        var parameter = Expression.Parameter(typeof(T));
        var leftBody = Expression.Invoke(leftExpression, parameter);
        var rightBody = Expression.Invoke(rightExpression, parameter);
        var body = Expression.Or(leftBody, rightBody);
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