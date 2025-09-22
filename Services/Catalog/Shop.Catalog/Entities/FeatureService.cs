using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shop.Catalog.Entities
{
    public class FeatureService
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureServiceID { get; set; }

        public string FeatureServiceTitle { get; set; }

        public string FeatureServiceIcon { get; set; }

    }
}
