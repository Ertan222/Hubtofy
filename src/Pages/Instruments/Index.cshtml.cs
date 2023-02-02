using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using src.Models;
using src.Services;
using RestSharp;

namespace src.Pages.Instruments;

public class IndexModel : PageModel {

	private readonly IInstrumentMongoService _instrumentMongoService;
	private readonly RestClient _client;	


	public IndexModel(IInstrumentMongoService instrumentMongoService) {
		_client = new RestClient("http://localhost:5078");
		_instrumentMongoService = instrumentMongoService; 
	}

	public List<Instrument>? AllInstruments { get; set; }

	public async Task OnGetAsync() {
		List<Instrument> allInstruments = await _instrumentMongoService.GetAll();
		AllInstruments = allInstruments.Count is 0 ? null : allInstruments;		
	}

	public async Task OnPostDeleteAsync(string id) {
		if(id is not null)
		_instrumentMongoService.Delete(id);

		ModelState.AddModelError("","There is no instrument with that id");
	}
	// Dummy
	public async Task<IActionResult> OnPostCreateDummyAsync() {
		await _instrumentMongoService.CreateDummy(); 
		return RedirectToPage("./Index");
	}

	public async Task<IActionResult> OnPostDeleteDummyAsync() {
		await _instrumentMongoService.DeleteDummy(); 
		return RedirectToPage("./Index");

	}
}
