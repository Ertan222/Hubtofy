using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Countrofy.Models;

namespace Countrofy.Services;

public interface ICountryMongoService
{
    
    Task<List<Country>> GetAll();
    Task<Country> GetById(string id);
    Task Add(Country country);
    Task Delete(string id);
    Task Update(Country country);
}
