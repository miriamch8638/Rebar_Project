using MongoDB.Bson.Serialization.Attributes;

namespace RebarProject3.Models
{
    
        public class OrderDB
        {
            [BsonId]
            public Guid ID { get; }
            public Guid OrderID { get; set; }
            public DateTime OrderCreateTime { get; set; }
            public DateTime ReadyOrderTime { get; set; }
            public List<Guid> ShakesID { get; set; } = new List<Guid>();
            public int TotalPrice { get; set; }
            public string CustomerName { get; set; }

            public OrderDB(DateTime orderCreateTime, List<Guid> shakesID, int totalPrice, string customerName)
            {
                OrderID = Guid.NewGuid();
                OrderCreateTime = orderCreateTime;
                ReadyOrderTime = DateTime.Now;
                ShakesID = shakesID;
                TotalPrice = totalPrice;
                CustomerName = customerName;
            }
        }
    }

