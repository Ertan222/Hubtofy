using Countrofy.Configuration;
using Countrofy.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// MongoDb Settings
builder.Services.Configure<CountrofyMongoDbSettings>(builder.Configuration.GetSection("MongoDb:CountrofyGeneral"));
builder.Services.Configure<MongoCountrySettings>(builder.Configuration.GetSection("MongoDb:Country"));
//

// Mongodb Services
builder.Services.AddSingleton<ICountryMongoService, CountryMongoService>();
//

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
