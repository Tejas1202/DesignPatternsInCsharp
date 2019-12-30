namespace DesignPatternsInCsharp.SOLIDPrinciples.OpenClose
{
    /// <summary>
    /// ISpecification implements the specification pattern which dictates whether or not
    /// the Product satisfies a particular criteria. You can think of ISpecification as a Predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
