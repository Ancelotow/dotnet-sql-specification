namespace Ancelotow.DbCore.Performance.Specs.Factories;

internal class SqlSpecificationFactory
{
    public static SqlSpecificationLogical<T> All<T>() => SqlSpecificationLogical<T>.All;
}