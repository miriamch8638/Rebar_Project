var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//using MongoDB.Driver;

//string connectionString = "mongodb://127.0.0.1:27017";
//string databaseName = "Rebar";
//string collectionShakes = "Types_Shakes";
//var client = new MongoClient(connectionString);
//var db = client.GetDatabase(databaseName);
//var collection = db.GetCollection<Shake>(collectionShakes);
//var Shake1 = new Shake { ShakeName = "rejoy", ShakeDescription = "בננה, ממרח אגוזי לוז, regurt, חלב",
//    PriceSizeL = 31, PriceSizeM = 27, PriceSizeS = 24 };

////var Shake1 = new Shake("rejoy", "בננה, ממרח אגוזי לוז, regurt, חלב", 28, 25, 24);
//await collection.InsertOneAsync(Shake1);
//var results = await collection.FindAsync(_ => true);
//foreach (var result in results.ToList())
//{
//    Console.WriteLine(value: $"{result.ShakeID}: {result.ShakeName}: {result.ShakeDescription}");

//}

