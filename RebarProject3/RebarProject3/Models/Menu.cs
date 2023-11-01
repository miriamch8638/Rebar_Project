namespace RebarProject3.Models
{
    public class Menu
    {
        public List<Shake> AllShakesMenu { get; set; }
        public Menu()
        {
            AllShakesMenu = new List<Shake>();

        }
        public void AddShake(Shake s)
        {
            try
            {
                AllShakesMenu.Add(s);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        public void ShowMenu()
        {
            foreach (var item in AllShakesMenu)
            {
                Console.WriteLine(item.ShakeName + item.ShakeDescription+ "  \n"
                    +" size L "+item.PriceSizeL+"\n" + " size M " + item.PriceSizeM
                    + "\n"+" size S " + item.PriceSizeS + "\n");
            }
        }
    }

}
