using MongoDB.Driver;
//using MongoDBapp;
using MongoDataAccess.Models;
using MongoDataAccess.DataAccess;


ShakeDataAccess db = new ShakeDataAccess();
//await db.CreateShake(new ShakeModel()
//{
//    ShakeName = "replay",
//    ShakeDescription = "תות, בננה, סורבה תות, regurt, תפוח סחוט",
//    PriceSizeL = 37,
//    PriceSizeM = 32,
//    PriceSizeS = 25
//});
var users=await db.GetAllShakes();
Console.WriteLine(users);