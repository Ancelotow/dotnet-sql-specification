using System.Linq.Expressions;

namespace Ancelotow.SqlSpecification.Specs;

/// <summary>
/// Specification design pattern for filtering SQL queries.
/// </summary>
/// <typeparam name="T">Data layer object</typeparam>
public interface ISqlSpecification<T>
{
    /// <summary>
    /// Transform specification to SQL-friendly expression
    /// </summary>
    /// <returns>SQL-friendly expression</returns>
    Expression<Func<T, bool>> ToExpression();
    
    /// <summary>
    /// Combine two specifications with AND operator
    /// </summary>
    /// <param name="other">Another specification</param>
    /// <returns>Combined specification</returns>
    ISqlSpecification<T> And(ISqlSpecification<T> other);

    /// <summary>
    /// Combine two specifications with OR operator
    /// </summary>
    /// <param name="other">Another specification</param>
    /// <returns>Combined specification</returns>
    ISqlSpecification<T> Or(ISqlSpecification<T> other);
    
    /// <summary>
    /// Negate the specification
    /// </summary>
    /// <returns>Negated specification</returns>
    ISqlSpecification<T> Not();
}