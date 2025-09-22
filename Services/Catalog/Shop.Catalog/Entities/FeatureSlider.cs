using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shop.Catalog.Entities
{
    public class FeatureSlider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureSliderID { get; set; }

        public string FeatureSliderTitle { get; set; }

        public string FeatureSliderDescription { get; set; }

        public string FeatureSliderImageUrl{ get; set; }

        public bool FeatureSliderStatus{ get; set; }
    }
}
