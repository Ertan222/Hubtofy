using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using src.Models;
using src.Services;

namespace src.Pages.Genres;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IGenreMongoService _genreMongoService;
    public IndexModel(ILogger<IndexModel> logger, IGenreMongoService genreMongoService)
    {
        _logger = logger;
        _genreMongoService = genreMongoService;
    }

    public List<Genre>? AllGenres { get; set; }
    public async Task OnGetAsync()
    {
        List<Genre> allGenres = await _genreMongoService.GetAllGenres();
        AllGenres = allGenres.Count is not 0 ? allGenres : null;
    }
        
    public async Task OnPostDeleteAsync(string id) {
        if (id is not null)
        {
            await _genreMongoService.DeleteGenre(id);
        }
        ModelState.AddModelError("","There is no item to delete");
    }

    // Dummy //
        public async Task<IActionResult> OnPostCreateDummyAsync() {
        await _genreMongoService.InsertDummyData();
        return RedirectToPage("./Index");
    }
    public async Task<IActionResult> OnPostDeleteDummyAsync() {
        await _genreMongoService.DeleteDummyData();
        return RedirectToPage("./Index");
    }
}
