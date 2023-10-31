using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using RebarProject3.Models;

namespace RebarProject3.DataAccess
{
    public class ShakeOrderDataAccess
    {
        public const string ConnectingString = "mongodb://127.0.0.1:27017";
        public const string DataBaseName = "Rebar";
        public string ShakeCollection = "Shakes";
        public const string OrdersCollection = "Orders";

        public static IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectingString);
            var db = client.GetDatabase(DataBaseName);
            return db.GetCollection<T>(collection);
        }
        public async Task<List<Shake>> GetAllShakes()
        {
            var shakesCollection = ConnectToMongo<Shake>(ShakeCollection);
            var result = await shakesCollection.FindAsync(_ => true);
            return result.ToList();
        }

        public async Task CreateShake(Shake s)
        {
            var shakesCollection = ConnectToMongo<Shake>(ShakeCollection);

            // Check if a similar object already exists in the collection
            var filter = Builders<Shake>.Filter.Eq(x => x.ShakeName, s.ShakeName)
                        & Builders<Shake>.Filter.Eq(x => x.ShakeDescription, s.ShakeDescription);
            var existingShake = await shakesCollection.Find(filter).FirstOrDefaultAsync();

            if (existingShake == null)
            {
                // If no similar object exists, insert the new Shake
                await shakesCollection.InsertOneAsync(s);
            }

        }

        //////////Delete
        public Task DeleteShake(Shake s)
        {
            var shakesCollection = ConnectToMongo<Shake>(ShakeCollection);

            return shakesCollection.DeleteOneAsync(c => c.ShakeID == s.ShakeID);
        }
    }
}
