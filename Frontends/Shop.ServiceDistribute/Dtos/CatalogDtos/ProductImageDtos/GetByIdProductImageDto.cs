namespace Shop.ServiceDistribute.Dtos.CatalogDtos.ProductImageDtos
{
    public class GetByIdProductImageDto
    {
        public string ProductImageID { get; set; }

        public string ProductImage1 { get; set; }

        public string ProductImage2 { get; set; }

        public string ProductImage3 { get; set; }

        public string ProductImage4 { get; set; }

        public bool IsActive { get; set; } = false;

        public string ProductID { get; set; }
    }
}
