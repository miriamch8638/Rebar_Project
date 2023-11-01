using MongoDB.Driver;
using RebarProject3.Models;

namespace RebarProject3.DataAccess
{
    public class OrdersDataAccess
    {
        private IMongoCollection<Order> ordersCollection;

        public OrdersDataAccess(IMongoDatabase database)
        {
            ordersCollection = database.GetCollection<Order>("Orders");
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var result = await ordersCollection.FindAsync(_ => true);
            return await result.ToListAsync();
        }


        public async Task CreateOrder(Order order, SalePromotion sale)
        {
            if (order.IsSale == true)
            {
                decimal c= sale.CalcTotal(order.TotalAmount, order.Date);
                order.TotalAmount = (int)c;
                UpdateOrder(order);
            }
            await ordersCollection.InsertOneAsync(order);
        }

        public async Task UpdateOrder(Order order)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrdeId, order.OrdeId);
            await ordersCollection.ReplaceOneAsync(filter, order);
        }

        public async Task DeleteOrder(Guid orderId)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrdeId, orderId);
            await ordersCollection.DeleteOneAsync(filter);
        }

    }
}

