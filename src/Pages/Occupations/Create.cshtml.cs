using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Services;
namespace src.Pages.Occupations;

public class CreateModel : PageModel {
	private readonly IOccupationMongoService _occupationMongoService;

	public CreateModel(IOccupationMongoService occupationMongoService) {
	_occupationMongoService = occupationMongoService;
	}
	[BindProperty]
	public Occupation? Occupation { get; set; }

	public async Task<IActionResult> OnPostCreateAsync() {
	await _occupationMongoService.Create(Occupation);
	return RedirectToPage("./Index");
	}
}
