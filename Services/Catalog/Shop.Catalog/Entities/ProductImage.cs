﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shop.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageID { get; set; }

        public string ProductImage1 { get; set; }

        public string ProductImage2 { get; set; }

        public string ProductImage3 { get; set; }

        public string ProductImage4 { get; set; }

        public string ProductID { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
 