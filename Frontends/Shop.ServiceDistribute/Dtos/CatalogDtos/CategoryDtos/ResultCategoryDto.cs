namespace Shop.ServiceDistribute.Dtos.CatalogDtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public string CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImageUrl { get; set; }

        public bool IsActive { get; set; } = false;


    }
}
