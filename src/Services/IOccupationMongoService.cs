using src.Models;
namespace src.Services;

public interface IOccupationMongoService {
	Task<List<Occupation>> GetAll();
	Task<Occupation> GetById(string id);
	Task Create(Occupation occupation);
	Task Delete(string id);
	Task Update(Occupation occupation);
	Task InsertDummyData();
	Task DeleteDummyData();
}
