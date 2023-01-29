using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Countrofy.Configuration;
using Countrofy.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Countrofy.Services;

public class CountryMongoService : ICountryMongoService
{
    private readonly IMongoCollection<Country> _countryCollection;
    public CountryMongoService(IOptions<CountrofyMongoDbSettings> countryMongoDbSettings, IOptions<MongoCountrySettings> mongoCountrySettings)
    {
        var client = new MongoClient(countryMongoDbSettings.Value.ConnectionString);
        var database = client.GetDatabase(countryMongoDbSettings.Value.Database);
        _countryCollection = database.GetCollection<Country>(mongoCountrySettings.Value.Collection); 
    }

    public Task<List<Country>> GetAll() => _countryCollection.FindAsync<Country>(_ => true).Result.ToListAsync();
    public Task<Country> GetById(string id) => _countryCollection.FindAsync<Country>(a => a.Id == id).Result.FirstOrDefaultAsync();
    public Task Add(Country country) => _countryCollection.InsertOneAsync(country);
    public Task Delete(string id) => _countryCollection.DeleteOneAsync<Country>(a => a.Id == id);
    public Task Update(Country country) => _countryCollection.ReplaceOneAsync<Country>(a => a.Id == country.Id, country);
}
