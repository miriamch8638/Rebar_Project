using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using RebarProject3.Models;


namespace RebarProject3.DataAccess
    {
        public class ShakeOrderDataAccess
        {
            private IMongoCollection<ShakeOrder> shakeOrdersCollection;

            public ShakeOrderDataAccess(IMongoDatabase database)
            {
                shakeOrdersCollection = database.GetCollection<ShakeOrder>("ShakeOrders");
            }

            public async Task<List<ShakeOrder>> GetAllShakeOrders()
            {
                var result = await shakeOrdersCollection.FindAsync(_ => true);
                return await result.ToListAsync();
            }



        public async Task UpdateShakeOrder(ShakeOrder shakeOrder)
            {
                var filter = Builders<ShakeOrder>.Filter.Eq(x => x.ShakeIdOrder, shakeOrder.ShakeIdOrder);
                await shakeOrdersCollection.ReplaceOneAsync(filter, shakeOrder);
            }

            public async Task DeleteShakeOrder(Guid shakeOrderId)
            {
                var filter = Builders<ShakeOrder>.Filter.Eq(x => x.ShakeIdOrder, shakeOrderId);
                await shakeOrdersCollection.DeleteOneAsync(filter);
            }
        }
    }

