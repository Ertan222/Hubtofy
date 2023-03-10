using src.Configuration;
using src.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// MongoDbSettings
builder.Services.Configure<HubtofyMongoDbSettings>(builder.Configuration.GetSection("Mongodb:HubtofyGeneral"));
builder.Services.Configure<MongoGenreSettings>(builder.Configuration.GetSection("MongoDb:Genre"));
builder.Services.Configure<MongoLabelSettings>(builder.Configuration.GetSection("MongoDb:Label"));
builder.Services.Configure<MongoInstrumentSettings>(builder.Configuration.GetSection("MongoDb:Instrument"));
builder.Services.Configure<MongoOccupationSettings>(builder.Configuration.GetSection("MongoDb:Occupation"));
//
// Mongo Services
builder.Services.AddSingleton<IGenreMongoService, GenreMongoService>();
builder.Services.AddSingleton<ILabelMongoService, LabelMongoService>();
builder.Services.AddSingleton<IInstrumentMongoService, InstrumentMongoService>();
builder.Services.AddSingleton<IOccupationMongoService, OccupationMongoService>();
//


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
