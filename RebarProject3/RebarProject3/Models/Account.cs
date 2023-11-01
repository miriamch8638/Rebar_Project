namespace RebarProject3.Models
{
    public class Account
    {
        public List<OrderDB> OrdersListInAccount { get; set; }
        public int TotalPriceAllOrders { get; set; }
        public Account()
        {
            OrdersListInAccount = new List<OrderDB>();
            TotalPriceAllOrders = 0;
        }
        public void GetToatlPrice()
        {
            foreach (var item in OrdersListInAccount)
            {
                TotalPriceAllOrders += item.TotalPrice;
            }
        }
        //    public void AddOrderToAcount(OrderDB o)
        //    {
        //        try
        //        {
        //            OrdersListInAccount.Add(o);
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);

        //        }
        //    }
        //}
    }
}
