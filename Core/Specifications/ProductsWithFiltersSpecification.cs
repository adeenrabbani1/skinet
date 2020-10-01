using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithFiltersSpecification : BaseSpecification<Product>
    {
        public ProductsWithFiltersSpecification(ProductsSpecParams ProductParams) : base(
            x => (string.IsNullOrEmpty(ProductParams.Search) || x.Name.ToLower().Contains(ProductParams.Search)) &&
             (!ProductParams.BrandId.HasValue || x.ProductBrandId == ProductParams.BrandId) &&
            (!ProductParams.TypeId.HasValue || x.ProductTypeId == ProductParams.TypeId)
        )
        {
        }
    }
}