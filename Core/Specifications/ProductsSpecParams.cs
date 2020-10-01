namespace Core.Specifications
{
    //this class represents the paramerters that products controller
    //expects to apply the  correct specification.
    public class ProductsSpecParams
    {
        public const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize { get; set; } = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize ? MaxPageSize : value);
        }
        private string _search;

        public string Search
        {
            get => _search;

            set => _search = value.ToLower();

        }
        public string Sort { get; set; }
        public int? BrandId { get; set; } //optional
        public int? TypeId { get; set; }  //optional
    }
}