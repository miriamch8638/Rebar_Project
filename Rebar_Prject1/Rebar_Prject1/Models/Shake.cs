﻿using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace Rebar_Prject1.Models
{
    public class Shake
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        private string shakeID;
        [BsonElement("shakeName")]
        private string shakeName;
        [BsonElement("shakeDescription")]
        private string shakeDescription;
        [BsonElement("priceSizeL")]
        private int priceSizeL;
        [BsonElement("priceSizeM")]
        private int priceSizeM;
        [BsonElement("priceSizeS")]
        private int priceSizeS;

        public string ShakeID
        {
            get { return shakeID; }
            set { shakeID = value; } // No validation in setter for ShakeID
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

