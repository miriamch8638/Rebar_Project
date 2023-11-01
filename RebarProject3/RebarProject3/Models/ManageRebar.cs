namespace RebarProject3.Models
{
    public class ManageRebar
    {
          private string password = "1234";
            public int NumOfOrdersToday { get; set; }
            public double DailyProfit { get; set; }
            public Menu Menu { get; set; }

            //public List<Shake> ShowMenu()
            //{
            //    return Menu.ShowMenu();
            //}

            public void TakeOrder(List<Shake> shakes)
            {

            }
        }
   
}
