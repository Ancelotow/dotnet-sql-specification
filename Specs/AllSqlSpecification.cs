using System.Linq.Expressions;

namespace Ancelotow.DbCore.Performance.Specs;

internal class AllSqlSpecification<T> : SqlSpecificationLogical<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return entity => true;
    }
}