namespace RebarProject3.Models
{
    public class Account
    {
        public List<Order> OrdersListInAccount { get; set; }
        public int TotalPriceAllOrders { get; set; }
        public Account()
        {
            OrdersListInAccount = new List<Order>();
            TotalPriceAllOrders = 0;
        }
        public void AddOrderToAcount(Order o)
        {
            try
            {
                OrdersListInAccount.Add(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }
    }
}
