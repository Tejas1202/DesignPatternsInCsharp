using System.Collections.Generic;

namespace DesignPatternsInCsharp.SOLIDPrinciples.OpenClose
{
    //Now here when we want to introduce a new filter, we just make a new class and derive from it and do not change
    //this class, hence it doesn't break OCP
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
                if (spec.IsSatisfied(item))
                    yield return item;
        }
    }
}
