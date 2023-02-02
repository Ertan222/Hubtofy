using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using src.Models;
using src.Services;

namespace src.Pages.Instruments;

public class CreateModel : PageModel
{
    private readonly ILogger<CreateModel> _logger;
    private readonly IInstrumentMongoService _instrumentMongoService;
    
    public CreateModel(ILogger<CreateModel> logger, IInstrumentMongoService instrumentMongoService)
    {
        _logger = logger;
        _instrumentMongoService = instrumentMongoService;
    }

    [BindProperty]
    public Instrument Instrument { get; set; }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostCreateAsync() {
        
        if (ModelState.IsValid)
        {
            await _instrumentMongoService.Create(Instrument);
            return RedirectToPage("./Index");
        }

        return Page();
    }
    
}
