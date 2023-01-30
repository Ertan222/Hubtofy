using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Models;

namespace src.Services;

public interface ILabelMongoService
{
    Task<List<Label>> GetAll();
    Task<Label> GetById(string id);
    Task Create(Label label);
    Task Delete(string id);
    Task Update(Label label);
    Task InsertDummyData();
    Task DeleteDummyData();
}
