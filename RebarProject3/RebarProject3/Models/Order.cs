namespace RebarProject3.Models
{
    public class Order
    {
        public Guid OrdeId { get; set; }
        public List<ShakeOrder> Shakes { get; set; }
        public int TotalAmount { get; set; }
        public String ClientName { get; set; }
        public DateTime Date { get; set; }
        public bool IsSale { get; set; }
        public Order(string clientName, DateTime date, bool isSale)
        {
            OrdeId = Guid.NewGuid();
            Shakes = new List<ShakeOrder>();
            TotalAmount = 0;
            ClientName = clientName;
            Date = date;
            IsSale = isSale;
        }
        public void AddShakeToOrder(ShakeOrder shake)
        {
            try
            {
                Shakes.Add(shake);
                TotalAmount += shake.Price;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }
}
