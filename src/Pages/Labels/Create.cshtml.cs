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

public class CreateModel : PageModel
{
    private readonly ILogger<CreateModel> _logger;
    private readonly ILabelMongoService _labelMongoService;
    private readonly RestClient _client;
    public CreateModel(ILogger<CreateModel> logger, ILabelMongoService labelMongoService)
    {
        _logger = logger;
        _client = new RestClient("http://localhost:5173");
        _labelMongoService = labelMongoService;
    }
    [BindProperty]
    public Label Label { get; set; }
    public List<Country> Countries { get; set; }
    public async Task OnGetAsync()
    {
        RestRequest request = new("Countries/GetAll");
        List<Country> allCountries = await _client.GetAsync<List<Country>>(request);
        Countries = allCountries;
    }

    public async Task<IActionResult> OnPostCreateAsync() {
        if (ModelState.IsValid)
        {
            await _labelMongoService.Create(Label);
            return RedirectToPage("./Index");
        }
        
        return Page();
    }

}
