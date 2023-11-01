
using RebarProject3.Models;
using MongoDB.Driver;


namespace RebarProject3.DataAccess
{
    public class DataAccess
    {
        public const string ConnectingString = "mongodb://127.0.0.1:27017";
        public const string DataBaseName = "Rebar";
        public const string ShakeCollection = "Shakes";
        public const string OrdersCollection = "Orders";
       
        //Shake Crud
        /************************/
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
        //////////update

        public Task UpdateShake(Shake s)
        {
            var shakesCollection = ConnectToMongo<Shake>(ShakeCollection);
            var filter = Builders<Shake>.Filter.Eq(field: "ShakeID", s.ShakeID);
            return shakesCollection.ReplaceOneAsync(filter, s, options: new ReplaceOptions { IsUpsert = true });
        }
        /**********************/
        //Orders Crud

        public async Task<List<OrderDB>> GetAllOrders()
        {
            var OrsersAllCollection = ConnectToMongo<OrderDB>(OrdersCollection);
            var result = await OrsersAllCollection.FindAsync(_ => true);
            return result.ToList();
        }
        
        //create order
        public async Task AddOrderToDB(OrderDB order)
        {
            var orderCollection = ConnectToMongo<OrderDB>(OrdersCollection);
            await orderCollection.InsertOneAsync(order);
        }
        public async Task CreateOrder(List<ShakeOrder> ShakeOrder, SalePromotion sale, string name)
        {
            if (ShakeOrder.Count <= 10 || !string.IsNullOrWhiteSpace(name))
            {
                var orderManager = new OrderManager();
                var shakesCollection = ConnectToMongo<Shake>(ShakeCollection);
                var shakeOrderList = new List<ShakeOrder>();
                foreach (var shakeOrder in ShakeOrder)
                {
                    var filter = Builders<Shake>.Filter.Eq(x => x.ShakeName, shakeOrder.Name);
                    var existingShake = await shakesCollection.Find(filter).FirstOrDefaultAsync();

                    if (existingShake != null)
                    {
                        orderManager.GetPrice(shakeOrder, existingShake);
                        shakeOrder.Description = existingShake.ShakeDescription;
                    }
                    else
                    {
                        Console.WriteLine("No matching Shake found for the ShakeOrder.");

                    }
                }
                int totalPrice = ShakeOrder.Sum(shakes => shakes.Price);
                int salePrice = (int)sale.CalcTotal(totalPrice, DateTime.Today);

                List<Guid> shakeIDs = ShakeOrder.ConvertAll(shakes => shakes.ShakeId);

                Order order = new Order(shakeOrderList, name, (int)totalPrice, salePrice);
                _ = AddOrderToDB(new OrderDB(order.Date, shakeIDs, totalPrice, name));
            }
        }

        //public async Task UpdateOrder(Order order)
        //{
        //    var filter = Builders<OrderDB>.Filter.Eq(x => x.OrdeId, order.OrdeId);
        //    await ordersCollection.ReplaceOneAsync(filter, order);
        //}

        //public async Task DeleteOrder(Guid orderId)
        //{
        //    var filter = Builders<Order>.Filter.Eq(x => x.OrdeId, orderId);
        //    await ordersCollection.DeleteOneAsync(filter);
        //}

    }
}
