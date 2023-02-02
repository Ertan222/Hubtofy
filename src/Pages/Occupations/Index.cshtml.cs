using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Services;
namespace src.Pages.Occupations;

public class IndexModel : PageModel {
	private readonly IOccupationMongoService _occupationMongoService;
	public IndexModel (IOccupationMongoService occupationMongoService) {
		_occupationMongoService = occupationMongoService;
	}

	public List<Occupation>? AllOccupations { get; set; }


	public async Task OnGetAsync() {
	List<Occupation> allOccupations = await _occupationMongoService.GetAll();
	AllOccupations = allOccupations.Count is 0 ? null: allOccupations;
	}

	public async Task<IActionResult> OnPostDeleteAsync(string id) {
	_occupationMongoService.Delete(id);
	return RedirectToPage("./Index");
	}
	//Dummy
	public async Task<IActionResult> OnPostCreateDummyAsync() {
	await _occupationMongoService.InsertDummyData();
	return RedirectToPage("./Index");
	}

	public async Task<IActionResult> OnPostDeleteDummyAsync() {
	await _occupationMongoService.DeleteDummyData();
	return RedirectToPage("./Index");
	}
}
