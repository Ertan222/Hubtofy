using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using src.Models;
using src.Services;

namespace src.Pages.Genres;

public class UpdateModel : PageModel
{
    private readonly ILogger<UpdateModel> _logger;
    private readonly IGenreMongoService _genreMongoService;

    public UpdateModel(ILogger<UpdateModel> logger, IGenreMongoService genreMongoService)
    {
        _logger = logger;
        _genreMongoService = genreMongoService;
    }    
    
    [BindProperty]
    public Genre Genre { get; set; }
    
    public async Task<IActionResult> OnGetAsync(string id)
    {
        Genre genre = await _genreMongoService.GetGenreById(id);
        if (genre is null)
        {
            return NotFound();
        }
        Genre = genre;
        return Page();
    }
    
    public async Task<IActionResult> OnPostUpdateAsync(string id) {
        
        if (ModelState.IsValid)
        {
            Genre.Id = id;
            await _genreMongoService.UpdateGenre(Genre);
            return RedirectToPage("./Index");
        }
        return Page();
    }
}