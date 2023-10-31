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

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string shakeID;
        private string shakeName;

        private string shakeDescription;

        private int priceSizeL;

        private int priceSizeM;

        private int priceSizeS;


        public string ShakeID
        {
            get { return shakeID; }
            set { shakeID = value; } 
        }
      
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
    
    }
  
}

