using System.Collections.Generic;

namespace DesignPatternsInCsharp.SOLIDPrinciples.OpenClose
{
    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
                if (product.Size == size)
                    yield return product;
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
                if (product.Color == color)
                    yield return product;
        }

        //Now suppose we're asked to filter by size and color, then we've to add new method
        //here which happens to break OCP (which means it should be possible to extend the ProductFilter
        //but it should be closed for modification bc we can assume that the filter might have already been shipped to the customer
        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var product in products)
                if (product.Size == size && product.Color == color)
                    yield return product;
        }
    }
}
