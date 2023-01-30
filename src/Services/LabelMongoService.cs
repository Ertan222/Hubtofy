using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using src.Configuration;
using src.Models;

namespace src.Services;

public class LabelMongoService : ILabelMongoService
{
    private readonly IMongoCollection<Label> _labelCollection;

    public LabelMongoService(IOptions<MongoLabelSettings> mongoLabelSettings,IOptions<HubtofyMongoDbSettings> hubtofyMongoDbSettings)
    {
        var client = new MongoClient(hubtofyMongoDbSettings.Value.ConnectionString);
        var database = client.GetDatabase(hubtofyMongoDbSettings.Value.Database);
        _labelCollection = database.GetCollection<Label>(mongoLabelSettings.Value.Collection);
    }

    public Task<List<Label>> GetAll() => _labelCollection.FindAsync<Label>(_ => true).Result.ToListAsync();
    public Task Create(Label label) => _labelCollection.InsertOneAsync(label);
    public Task<Label> GetById(string id) => _labelCollection.FindAsync<Label>(a => a.Id == id).Result.FirstOrDefaultAsync();
    public Task Delete(string id) => _labelCollection.DeleteOneAsync<Label>(a => a.Id == id);
    public Task Update(Label label) => _labelCollection.ReplaceOneAsync<Label>(a => a.Id == label.Id, label);
    
    // Dummy
    public Task InsertDummyData() => _labelCollection.InsertManyAsync(DummyLabels);
    public Task DeleteDummyData() => _labelCollection.DeleteManyAsync<Label>(_ => true);

    public List<Label> DummyLabels { get; set; } = new() {
        new Label {Name = "Columbia Records", Founded = Convert.ToDateTime("1889/1/15"), Location = "New York City, New York, U.S.", CountryOfOrigin = "United States", Parent = "Sony Music Entertainment", Website = "www.columbiarecords.com", Defunct = false},
        new Label {Name = "EMI Records", Founded = Convert.ToDateTime("1973/7/1"), Location = "London, UK", CountryOfOrigin = "United Kingdom", Parent = "Electric and Musical Industries", Website = "emirecords.com", Defunct = true},
        new Label {Name = "Atlantic Records", Founded = Convert.ToDateTime("1947/1/1"), Location = "New York City, New York", CountryOfOrigin = "United States", Parent = "Warner Music Group", Website = "atlanticrecords.com"},
    };    
    
}
