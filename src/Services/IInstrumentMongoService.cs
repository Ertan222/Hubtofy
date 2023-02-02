using src.Models;
namespace src.Services;

public interface IInstrumentMongoService {
	Task<List<Instrument>> GetAll();
	Task<Instrument> GetById(string id);
	Task Create(Instrument instrument);
	Task Delete(string id);
	Task Update(Instrument instrument);
	Task CreateDummy();
	Task DeleteDummy();
}
