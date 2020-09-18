using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithBrandAndTypesSpecification : BaseSpecification<Product>
    {
        public ProductWithBrandAndTypesSpecification()
        {
            this.AddInclude(p => p.ProductType);
            this.AddInclude(p => p.ProductBrand);
        }

        public ProductWithBrandAndTypesSpecification(int id) : base(p => p.Id == id)
        {
            this.AddInclude(p => p.ProductType);
            this.AddInclude(p => p.ProductBrand);
        }
    }
}