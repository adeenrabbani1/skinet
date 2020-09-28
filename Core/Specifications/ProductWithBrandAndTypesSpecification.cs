using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithBrandAndTypesSpecification : BaseSpecification<Product>
    {
        public ProductWithBrandAndTypesSpecification(ProductsSpecParams ProductParams)
        : base(
            x => (!ProductParams.BrandId.HasValue || x.ProductBrandId == ProductParams.BrandId) &&
            (!ProductParams.TypeId.HasValue || x.ProductTypeId == ProductParams.TypeId)
        )
        {
            //registration of specs of query to be executed.
            //methods provided by basespecification.
            this.AddInclude(p => p.ProductType);
            this.AddInclude(p => p.ProductBrand);

            //adding pagination specs.
            this.AddPagination(ProductParams.PageSize * (ProductParams.PageIndex - 1), ProductParams.PageSize);


            switch (ProductParams.Sort)
            {
                case "priceAsc":
                    {
                        this.AddOrderBy(p => p.Price);
                        break;
                    }
                case "priceDesc":
                    {
                        this.AddOrderByDesc(p => p.Price);
                        break;
                    }
                default:
                    this.AddOrderBy(p => p.Name);
                    break;
            }

        }

        public ProductWithBrandAndTypesSpecification(int id) : base(p => p.Id == id)
        {
            this.AddInclude(p => p.ProductType);
            this.AddInclude(p => p.ProductBrand);
        }
    }
}