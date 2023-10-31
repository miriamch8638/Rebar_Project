

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Xml.Linq;


namespace RebarProject3.Models
{
    public class Shake
    {

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //private string shakeID;
        [BsonId]
        public Guid Id { get; }
        public Guid ShakeID { get; set; }

        private string shakeName;

        private string shakeDescription;

        private int priceSizeL;

        private int priceSizeM;

        private int priceSizeS;


        //public string ShakeID
        //{
        //    get { return shakeID; }
        //    set { shakeID = value; }
        //}

        public string ShakeName
        {
            get { return shakeName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("ShakeName cannot be empty or null.");
                }
                else
                {
                    shakeName = value;
                }
            }
        }

        public string ShakeDescription
        {
            get { return shakeDescription; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("ShakeDescription cannot be empty or null.");
                }
                else
                {
                    shakeDescription = value;
                }
            }
        }

        public int PriceSizeL
        {
            get { return priceSizeL; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("PriceSizeL cannot be negative.");
                }
                else
                {
                    priceSizeL = value;
                }
            }
        }

        public int PriceSizeM
        {
            get { return priceSizeM; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("PriceSizeM cannot be negative.");
                }
                else
                {
                    priceSizeM = value;
                }
            }
        }

        public int PriceSizeS
        {
            get { return priceSizeS; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("PriceSizeS cannot be negative.");
                }
                else
                {
                    priceSizeS = value;
                }
            }
        }
        public Shake(string name, string description, int priceSmall, int priceMedium, int priceLarge)
        {
            ShakeID = Guid.NewGuid();
            ShakeName = name;
            ShakeDescription = description;
            PriceSizeS = priceSmall;
            PriceSizeM = priceMedium;
            PriceSizeL = priceLarge;
        }

    }

}
