using MongoDB.Driver;
using src.Configuration;
using src.Models;
using Microsoft.Extensions.Options;

namespace src.Services;

public class OccupationMongoService : IOccupationMongoService
{
    private readonly IMongoCollection<Occupation> _occupationCollection;

    public OccupationMongoService(IOptions<MongoOccupationSettings> mongoOccupationSettings,IOptions<HubtofyMongoDbSettings> hubtofyMongoDbSettings)
    {
        var client = new MongoClient(hubtofyMongoDbSettings.Value.ConnectionString);
        var database = client.GetDatabase(hubtofyMongoDbSettings.Value.Database);
        _occupationCollection = database.GetCollection<Occupation>(mongoOccupationSettings.Value.Collection);
    }

    public Task<List<Occupation>> GetAll() => _occupationCollection.FindAsync<Occupation>(_ => true).Result.ToListAsync();
    public Task Create(Occupation occupation) => _occupationCollection.InsertOneAsync(occupation);
    public Task<Occupation> GetById(string id) => _occupationCollection.FindAsync<Occupation>(a => a.Id == id).Result.FirstOrDefaultAsync();
    public Task Delete(string id) => _occupationCollection.DeleteOneAsync<Occupation>(a => a.Id == id);
    public Task Update(Occupation occupation) => _occupationCollection.ReplaceOneAsync<Occupation>(a => a.Id == occupation.Id, occupation);
    
    // Dummy
    public Task InsertDummyData() => _occupationCollection.InsertManyAsync(DummyOccupations);
    public Task DeleteDummyData() => _occupationCollection.DeleteManyAsync<Occupation>(_ => true);
    
    private List<Occupation> DummyOccupations { get; set; } = new() {
	new Occupation { Name = "Musician"},
	new Occupation { Name = "Singer"},
	new Occupation { Name = "Songwriter"},
	new Occupation { Name = "Composer"},
	new Occupation { Name = "Record Producer"},
	new Occupation { Name = "Author"},
	new Occupation { Name = "Auto Racer"},
    };

}

