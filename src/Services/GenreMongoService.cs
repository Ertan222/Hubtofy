using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using src.Configuration;
using src.Models;

namespace src.Services;

public class GenreMongoService : IGenreMongoService
{
    private readonly IMongoCollection<Genre> _genreCollection;

    public GenreMongoService(IOptions<MongoGenreSettings> mongoGenreSettings, IOptions<HubtofyMongoDbSettings> hubtofyMongoDbSettings)
    {
        var client = new MongoClient(hubtofyMongoDbSettings.Value.ConnectionString);
        var database = client.GetDatabase(hubtofyMongoDbSettings.Value.Database);
        _genreCollection = database.GetCollection<Genre>(mongoGenreSettings.Value.Collection);
    }
    public async Task<List<Genre>> GetAllGenres() => await _genreCollection.FindAsync<Genre>(_=> true).Result.ToListAsync();
    public async Task<Genre> GetGenreById(string id) => await _genreCollection.FindAsync<Genre>(a => a.Id == id).Result.FirstOrDefaultAsync();
    public async Task AddGenre(Genre genre) => await _genreCollection.InsertOneAsync(genre); 
    public async Task DeleteGenre(string id) => await _genreCollection.DeleteOneAsync<Genre>(a => a.Id == id);
    public async Task UpdateGenre(Genre genre) => await _genreCollection.ReplaceOneAsync<Genre>(a => a.Id == genre.Id, genre);

    // Seed Data Methods/Functions //
    public async Task InsertDummyData() => await _genreCollection.InsertManyAsync(DummyGenres); 
    public async Task DeleteDummyData() => await _genreCollection.DeleteManyAsync(_ => true); 

    public List<Genre> DummyGenres { get; set; } = new() {
        new Genre { Name = "Rock"},
        new Genre { Name = "Metal"},
        new Genre { Name = "Punk"}
    };
}
