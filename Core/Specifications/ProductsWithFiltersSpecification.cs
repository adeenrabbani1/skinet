using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithFiltersSpecification : BaseSpecification<Product>
    {
        public ProductsWithFiltersSpecification(ProductsSpecParams ProductParams) : base(
            x => (!ProductParams.BrandId.HasValue || x.ProductBrandId == ProductParams.BrandId) &&
            (!ProductParams.TypeId.HasValue || x.ProductTypeId == ProductParams.TypeId)
        )
        {
        }
    }
}