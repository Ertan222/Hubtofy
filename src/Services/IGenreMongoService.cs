using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Models;

namespace src.Services;

public interface IGenreMongoService
{
    Task<List<Genre>> GetAllGenres();
    Task<Genre> GetGenreById(string id);
    Task AddGenre(Genre genre);
    Task DeleteGenre(string id);
    Task UpdateGenre(string id, Genre genre);
    Task InsertDummyData();
    Task DeleteDummyData();
}
