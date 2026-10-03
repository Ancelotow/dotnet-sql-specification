using System.Linq.Expressions;

namespace Ancelotow.SqlSpecification.Specs;

internal class AllSqlSpecification<T> : SqlSpecificationLogical<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return entity => true;
    }
}