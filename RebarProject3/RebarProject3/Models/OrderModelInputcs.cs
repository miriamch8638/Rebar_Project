namespace RebarProject3.Models
{
    public class OrderModelInputcs
    {
      
            public List<ShakeOrder> ShakeOrder { get; set; }
            public SalePromotion sale { get; set; }
            public string Name { get; set; }

            public OrderModelInputcs() { }
      
    }
}
