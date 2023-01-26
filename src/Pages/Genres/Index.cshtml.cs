using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using src.Models;
using src.Services;

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

    [BindProperty]
    public Genre? Genre { get; set; }
    public async Task<IActionResult> OnPostCreateAsync() {
        
        if (ModelState.IsValid)
        {
            await _genreMongoService.AddGenre(Genre);
            return RedirectToPage("./Index");
        }

        return RedirectToPage("./Index");
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
