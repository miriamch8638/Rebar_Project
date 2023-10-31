using MongoDataAccess.DataAccess;
using MongoDataAccess.Models;
using MongoDB.Driver;

namespace MongoDataAccess.DataAccess
{
    public class ShakeDataAccess
    {
        private const string ConnectingString = "mongodb://127.0.0.1:27017";
        private const string DataBaseName = "Rebar";
        private const string ShakeCollection = "Types_Shakes";
        private const string OrdersCollection = "Orders";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectingString);
            var db = client.GetDatabase(DataBaseName);
            return db.GetCollection<T>(collection);
        }
        public async Task<List<ShakeModel>> GetAllShakes()
        {
            var shakesCollection = ConnectToMongo<ShakeModel>(ShakeCollection);
            var result = await shakesCollection.FindAsync(_ => true);
            return result.ToList();
        }
        //public Task CreateShake(ShakeModel s)
        //{
        //    var shakesCollection = ConnectToMongo<ShakeModel>(ShakeCollection);

        //    return shakesCollection.InsertOneAsync(s);
        //}
        public async Task CreateShake(ShakeModel s)
        {
            var shakesCollection = ConnectToMongo<ShakeModel>(ShakeCollection);

            // Check if a similar object already exists in the collection
            var filter = Builders<ShakeModel>.Filter.Eq(x => x.ShakeName, s.ShakeName)
                        & Builders<ShakeModel>.Filter.Eq(x => x.ShakeDescription, s.ShakeDescription);
            var existingShake = await shakesCollection.Find(filter).FirstOrDefaultAsync();

            if (existingShake == null)
            {
                // If no similar object exists, insert the new ShakeModel
                await shakesCollection.InsertOneAsync(s);
            }
         
        }

        //////////update

        //public Task UpdateShake(ShakeModel s)
        //{
        //    var shakesCollection = ConnectToMongo<ShakeModel>(ShakeCollection);
        //    var filter = Builders<ShakeModel>.Filter.Eq(field: "ShakeID", s.ShakeID);
        //    return shakesCollection.ReplaceOneAsync(filter, s, options: new ReplaceOptions { IsUpsert = true });
        //}


        //////////Delete
        public Task DeleteShake(ShakeModel s)
        {
            var shakesCollection = ConnectToMongo<ShakeModel>(ShakeCollection);

            return shakesCollection.DeleteOneAsync(c=>c.ShakeID== s.ShakeID);   
        }
    }
}
