namespace RebarProject3.Models
{
    public class OrderManager
    {

        private Order Order;
        private OrderDB OrderDB;

        public OrderManager() { }

        public bool CreateOrder(List<ShakeOrder> shakesList, SalePromotion salePromotion, string name)
        {
            if (shakesList.Count > 9 || string.IsNullOrWhiteSpace(name))
                return false;
            double totalPrice = shakesList.Sum(shakes => shakes.Price);
            decimal totalSalePromotion = salePromotion.CalcTotal(Order.TotalPrice, Order.Date);
            List<Guid> shakeIDs = shakesList.ConvertAll(shakes => shakes.ShakeId);

            Order = new Order(shakesList, name, (int)totalPrice, (int)totalSalePromotion);
            OrderDB = new OrderDB(Order.Date, shakeIDs, totalPrice, name);

            return true;
        }
        public void GetPrice(ShakeOrder shakeToUpdate, Shake shake)
        {
            if (shake != null)
            {
                shakeToUpdate.Description = shake.ShakeDescription;
                switch (shakeToUpdate.Size)
                {
                    case chooseSize.s:
                        shakeToUpdate.Price = shake.PriceSizeS;
                        break;
                    case chooseSize.m:
                        shakeToUpdate.Price = shake.PriceSizeM;
                        break;
                        shakeToUpdate.Price = shake.PriceSizeL;
                    case chooseSize.l:
                        break;
                    default:
                        break;
                }

            }
        }

    }
}
