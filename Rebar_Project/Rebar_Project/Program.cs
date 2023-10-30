using MongoDB.Driver;
using MongoDBapp;

string connectionString = "mongodb://127.0.0.1:27017";
string databaseName = "Rebar";
string collectionShakes = "Types_Shakes";
var client = new MongoClient(connectionString);
var db = client.GetDatabase(databaseName);
var collection = db.GetCollection<ShakeModel>(collectionShakes);

var Shake1 = new ShakeModel { ShakeName = "rejoy", ShakeDescription = "בננה, ממרח אגוזי לוז, regurt, חלב", PriceSizeL = 31, PriceSizeM = 27, PriceSizeS = 24 };
await collection.InsertOneAsync(Shake1);
var results = await collection.FindAsync(_=>true);
foreach (var result in results.ToList())
{
    Console.WriteLine(value:$"{result.ShakeID}: {result.ShakeName}: {result.ShakeDescription}");

}