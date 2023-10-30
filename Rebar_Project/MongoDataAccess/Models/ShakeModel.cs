using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataAccess.Models
{
    public class ShakeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ShakeID { get; set; }
        public string ShakeName { get; set; }
        public string ShakeDescription { get; set; }
        public int PriceSizeL { get; set; }
        public int PriceSizeM { get; set; }
        public int PriceSizeS { get; set; }
    }
}
