using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using src.Models;
using src.Services;

public class AddModel : PageModel
{
    private readonly ILogger<AddModel> _logger;
    private readonly IGenreMongoService _genreMongoService;
    public AddModel(ILogger<AddModel> logger, IGenreMongoService genreMongoService)
    {
        _logger = logger;
        _genreMongoService = genreMongoService;
    }

    public void OnGet()
    {
    }
}
