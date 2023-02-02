using MongoDB.Driver;
using src.Models;
using src.Configuration;
using src.Services;
using Microsoft.Extensions.Options;

public class InstrumentMongoService : IInstrumentMongoService {
	public readonly IMongoCollection<Instrument> _ınstrumentCollection;

	public InstrumentMongoService(IOptions<MongoInstrumentSettings> mongoInstrumentSettings, IOptions<HubtofyMongoDbSettings> hubtofyMongoDbSettings) {
		var client = new MongoClient(hubtofyMongoDbSettings.Value.ConnectionString);	
		var database = client.GetDatabase(hubtofyMongoDbSettings.Value.Database);
		_ınstrumentCollection = database.GetCollection<Instrument>(mongoInstrumentSettings.Value.Collection);
	}

	public Task<List<Instrument>> GetAll() => _ınstrumentCollection.FindAsync<Instrument>(_ => true).Result.ToListAsync();
	public Task<Instrument> GetById(string id) => _ınstrumentCollection.FindAsync<Instrument>(a => a.Id == id).Result.FirstOrDefaultAsync();
	public Task Create(Instrument instrument) => _ınstrumentCollection.InsertOneAsync(instrument);
	public Task Delete(string id) => _ınstrumentCollection.DeleteOneAsync<Instrument>(a => a.Id == id);
	public Task Update(Instrument instrument) => _ınstrumentCollection.ReplaceOneAsync<Instrument>(a => a.Id == instrument.Id, instrument);

	// Dummy

	public Task CreateDummy() => _ınstrumentCollection.InsertManyAsync(DummyInstruments);
	public Task DeleteDummy() => _ınstrumentCollection.DeleteManyAsync(_ => true);

	public List<Instrument> DummyInstruments { get; set; } = new() {
	    new Instrument { Name = "Guitar"},
	    new Instrument { Name = "Vocals"},
	    new Instrument { Name = "Drums"},
	    new Instrument { Name = "Percussion"},
	    new Instrument { Name = "Bass Guitar"},
	    new Instrument { Name = "Keyboards"},
	    new Instrument { Name = "Harmonica"},
	    new Instrument { Name = "Bass"},
	    new Instrument { Name = "Keyboards"}
	};	

}
