using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RestSharp;
using src.DTO;
using src.Models;
using src.Services;

namespace src.Pages.Labels;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ILabelMongoService _labelMongoService;
    public IndexModel(ILogger<IndexModel> logger, ILabelMongoService labelMongoService)
    {
        _logger = logger;
        _labelMongoService = labelMongoService;
    }
    public List<Label>? AllLabels { get; set; }
    
    public async Task OnGetAsync()
    {
        List<Label> allLabels = await _labelMongoService.GetAll();
        AllLabels = allLabels.Count is 0 ? null : allLabels;
    }
    public async Task OnPostDeleteAsync(string id) {
        if (id is not null)
        {
            await _labelMongoService.Delete(id);
        }
        ModelState.AddModelError("","There is no item to delete");
    }
    
    public async Task<IActionResult> OnGetDetailAsync(string id) {
        if (id is not null)
        {
            Label label = await _labelMongoService.GetById(id);
            string serializedLabel = JsonSerializer.Serialize<Label>(label);
            return new JsonResult(new {}) {StatusCode = 200,  ContentType = "application/json", Value = serializedLabel};
        }
        return NotFound();
    }
    // Dummy //
        public async Task<IActionResult> OnPostCreateDummyAsync() {
        await _labelMongoService.InsertDummyData();
        return RedirectToPage("./Index");
    }
    public async Task<IActionResult> OnPostDeleteDummyAsync() {
        await _labelMongoService.DeleteDummyData();
        return RedirectToPage("./Index");
    }
}
