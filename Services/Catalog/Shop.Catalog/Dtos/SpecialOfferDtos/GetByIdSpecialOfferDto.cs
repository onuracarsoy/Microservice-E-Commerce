namespace Shop.Catalog.Dtos.SpecialOfferDtos
{
    public class GetByIdSpecialOfferDto
    {
        public string SpecialOfferID { get; set; }

        public string SpecialOfferTitle { get; set; }

        public string SpecialOfferSubTitle { get; set; }

        public string SpecialOfferImageUrl { get; set; }

        public bool SpecialOfferStatus { get; set; }
    }
}
