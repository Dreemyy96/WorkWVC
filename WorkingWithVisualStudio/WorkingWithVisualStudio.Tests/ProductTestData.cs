﻿using System.Collections;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetPricesUnder50() };
            yield return new object[] { GetPricesOver50() };
        }

        private Product[] GetPricesOver50() => new Product[]
        {
            new Product (){ Name = "P1", Price = 5M},
            new Product (){ Name = "P2", Price = 48.95M},
            new Product (){ Name = "P3", Price = 19.50M},
            new Product (){ Name = "P4", Price = 34.95M}
        };

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<Product> GetPricesUnder50()
        {
            decimal[] priceArray = new decimal[] { 275, 49.95M, 19.50M, 24.95M };
            for (int i = 0; i < priceArray.Length; i++)
            {
                yield return new Product() { Name = $"P{i + 1}", Price = priceArray[i] };
            }
        }

    }
}
