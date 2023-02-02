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

public class UpdateModel : PageModel
{
	private readonly ILogger<UpdateModel> _logger;
	private readonly IInstrumentMongoService _instrumentMongoService;

	public UpdateModel(ILogger<UpdateModel> logger, IInstrumentMongoService instrumentMongoService)
	{
		_logger = logger;
		_instrumentMongoService = instrumentMongoService;
	}    

	[BindProperty]
	public Instrument Instrument { get; set; }

	public async Task<IActionResult> OnGetAsync(string id)
	{
		Instrument instrument = await _instrumentMongoService.GetById(id);
		if (instrument is null)
		{
			return NotFound();
		}
		Instrument = instrument;
		return Page();
	}

	public async Task<IActionResult> OnPostUpdateAsync(string id) {

		if (ModelState.IsValid)
		{
			Instrument.Id = id;
			await _instrumentMongoService.Update(Instrument);
			return RedirectToPage("./Index");
		}
		Instrument.Id = id;
		return Page();
	}
}
