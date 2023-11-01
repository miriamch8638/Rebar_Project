//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
//************************************************************
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

//***********************************************

using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using RebarProject3.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add your configuration, such as appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddSingleton<IMongoClient>(ServiceProvider => new MongoClient(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddTransient<MongoService>();
builder.Services.AddControllers();
////////**********
builder.Services.AddScoped<DataAccess>();
// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RebarAPI", Version = "v1" });
});

var app = builder.Build();

// Use exception handling middleware (good for development)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Use HTTPS redirection
app.UseHttpsRedirection();

// Use Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RebarAPI V1");
});

// Use the routing middleware
app.UseRouting();

// Configure the routes for your controllers
app.MapControllers();

var databaseName = builder.Configuration["ConnectionStrings:DatabaseName"];
Console.WriteLine($"Using database: {databaseName}");

app.Run();