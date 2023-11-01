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
    public struct SalePromotion
    {
        public string Name { get; set; }   
        public decimal DiscountPercentage { get; set; }  
        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }    

        public SalePromotion(string name, decimal discountPercentage, DateTime startDate, DateTime endDate)
        {
            Name = name;
            DiscountPercentage = discountPercentage;
            StartDate = startDate;
            EndDate = endDate;
        }
        public decimal CalcTotal(decimal CurrntTotal,DateTime d)
        {
            if(d<=EndDate&&d>=StartDate)
            {
                CurrntTotal *= DiscountPercentage;
                return CurrntTotal / 100;
            }
            return CurrntTotal;
        }
        public override string ToString()
        {
            return $"{Name} ({DiscountPercentage}% off) from {StartDate:d} to {EndDate:d}";
        }
    }

}
