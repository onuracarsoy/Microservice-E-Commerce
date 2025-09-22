namespace Shop.ServiceDistribute.Dtos.CatalogDtos.SpecialOfferDtos
{
    public class ResultSpecialOfferDto
    {
        public string SpecialOfferID { get; set; }

        public string SpecialOfferTitle { get; set; }

        public string SpecialOfferSubTitle { get; set; }

        public string SpecialOfferImageUrl { get; set; }

        public bool SpecialOfferStatus { get; set; }

        public bool IsActive { get; set; }
    }
}
