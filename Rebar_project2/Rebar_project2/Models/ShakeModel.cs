using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataAccess.Models
{
    public class ShakeModel
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.String)]
        public Guid ShakeID { get; set; }
        private string shakeName;
        private string shakeDescription;
        private int priceSizeL;
        private int priceSizeM;
        private int priceSizeS;

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
        public ShakeModel(string shakeName, string description, int priceSizeS, int priceSizeM, int priceSizeL)
        {
            ShakeID = Guid.NewGuid();
            ShakeName = shakeName;
            ShakeDescription = description;
            PriceSizeL = priceSizeL;
            PriceSizeM = priceSizeM;
            PriceSizeS = priceSizeS;
        }
    }
    //public ShakeModel(string shakeName, string description, int priceSizeS, int priceSizeM, int priceSizeL)
    //{
    //    ShakeName = shakeName;
    //    ShakeDescription = description;
    //    PriceSizeL = priceSizeL;
    //    PriceSizeM = priceSizeM;
    //    PriceSizeS = priceSizeS;
    //}
}


//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
//namespace MongoDataAccess.Models
//{
//    public class ShakeModel
//    {
//        [BsonId]
//        public Guid ShakeID { get; set; }
//        [BsonElement("Name")]
//        public string ShakeName { get; set; }
//        [BsonElement("Description")]
//        public string ShakeDescription { get; set; }
//        [BsonElement("PriceSmall")]
//        public int PriceSizeS { get; set; }
//        [BsonElement("PriceMedium")]
//        public int PriceSizeM { get; set; }
//        [BsonElement("PriceLarge")]
//        public int PriceSizeL { get; set; }

//        public enum ShakeSize
//        {
//            Small,
//            Medium,
//            Large
//        }

//        public ShakeModel(string name, string description, int priceSmall, int priceMedium, int priceLarge)
//        {
//            ShakeID = Guid.NewGuid(); // Unique ID generation
//            ShakeName = name;
//            ShakeDescription = description;
//            PriceSizeS = priceSmall;
//            PriceSizeM = priceMedium;
//            PriceSizeL = priceLarge;
//        }

//        public decimal GetPrice(ShakeSize size)
//        {
//            switch (size)
//            {
//                case ShakeSize.Small:
//                    return PriceSizeS;
//                case ShakeSize.Medium:
//                    return PriceSizeM;
//                case ShakeSize.Large:
//                    return PriceSizeL;
//                default:
//                    return 0;
//            }
//        }


//    }
//}


