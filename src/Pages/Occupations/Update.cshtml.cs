using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using src.Models;
using src.Services;

namespace src.Pages.Occupations;

public class UpdateModel : PageModel
{
    private readonly IOccupationMongoService _occupationMongoService;

    public UpdateModel(ILogger<UpdateModel> logger, IOccupationMongoService occupationMongoService)
    {
        _occupationMongoService = occupationMongoService;
    }    
    
    [BindProperty]
    public Occupation Occupation { get; set; }
    
    public async Task<IActionResult> OnGetAsync(string id)
    {
        Occupation occupation = await _occupationMongoService.GetById(id);
        if (occupation is null)
        {
            return NotFound();
        }
        Occupation = occupation;
        return Page();
    }
    
    public async Task<IActionResult> OnPostUpdateAsync(string id) {
        
        if (ModelState.IsValid)
        {
            Occupation.Id = id;
            await _occupationMongoService.Update(Occupation);
            return RedirectToPage("./Index");
        }
        return Page();
    }
}
