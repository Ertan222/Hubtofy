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

public class CreateModel : PageModel
{
    private readonly ILogger<CreateModel> _logger;
    private readonly IGenreMongoService _genreMongoService;
    
    public CreateModel(ILogger<CreateModel> logger, IGenreMongoService genreMongoService)
    {
        _logger = logger;
        _genreMongoService = genreMongoService;
    }

    [BindProperty]
    public Genre Genre { get; set; }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostCreateAsync() {
        
        if (ModelState.IsValid)
        {
            await _genreMongoService.AddGenre(Genre);
            return RedirectToPage("./Index");
        }

        return Page();
    }
    
}
