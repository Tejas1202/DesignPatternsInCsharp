using System.Collections.Generic;

namespace DesignPatternsInCsharp.SOLIDPrinciples.OpenClose
{
    interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
}
