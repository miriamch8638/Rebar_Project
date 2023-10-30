

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoDBapp;

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
