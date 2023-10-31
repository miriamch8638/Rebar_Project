namespace RebarProject3.Models
{
    public enum chooseSize
    {
        s,
        m,
        l
    }
    public class ShakeOrder
    {
        public Guid ShakeId { get; set; }
        public string Name { get; set; }
        public chooseSize Size { get; set; }
        public int Price { get; set; }
        public Guid ShakeIdOrder { get; set; }
        public ShakeOrder(Guid shakeId,string name,chooseSize s,int price)
        {
            ShakeId= shakeId;
            Name= name; 
            Size= s;
            Price= price;
            ShakeIdOrder=Guid.NewGuid();
        }
    }
}

