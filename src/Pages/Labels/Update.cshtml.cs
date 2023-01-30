using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RestSharp;
using src.DTO;
using src.Models;
using src.Services;

namespace src.Pages.Labels;

public class UpdateModel : PageModel
{
    private readonly ILogger<UpdateModel> _logger;
    private readonly ILabelMongoService _labelMongoService;
    private readonly RestClient _client;
    
    public UpdateModel(ILogger<UpdateModel> logger, ILabelMongoService labelMongoService)
    {
        _logger = logger;
        _client = new RestClient("http://localhost:5173");
        _labelMongoService = labelMongoService;
    }
    [BindProperty]
    public Label Label { get; set; }
    public List<Country> Countries { get; set; }
    public async Task<IActionResult> OnGetAsync(string id)
    {
        Label label = await _labelMongoService.GetById(id);
        if (label is null)
        {
            return NotFound();
        }

        RestRequest request = new("Countries/GetAll");
        List<Country> allCountries = await _client.GetAsync<List<Country>>(request);
        Countries = allCountries;
        Label = label;
        return Page();
    }

    public async Task<IActionResult> OnPostUpdateAsync(string id) {
        if (ModelState.IsValid)
        {
            Label.Id = id;
            await _labelMongoService.Update(Label);
            return RedirectToPage("./Index");
        }
        
        return Page();
    }
}
