using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shop.Catalog.Entities
{
    public class SpecialOffer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialOfferID { get; set; }

        public string SpecialOfferTitle { get; set; }

        public string SpecialOfferSubTitle{ get; set; }

        public string SpecialOfferImageUrl { get; set; }

        public bool SpecialOfferStatus { get; set; }
    }
}
