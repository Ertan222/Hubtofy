using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Countrofy.DTO;
using Countrofy.Models;
using Countrofy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Countrofy.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ILogger<CountriesController> _logger;
    private readonly ICountryMongoService _countryMongoService;

    public CountriesController(ILogger<CountriesController> logger, ICountryMongoService countryMongoService)
    {
        _logger = logger;
        _countryMongoService = countryMongoService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll() {
        List<Country> allCountries = await _countryMongoService.GetAll();
        return allCountries.Count is 0 ? NotFound() : Ok(allCountries);
    }
    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetById(string id) {
        Country country = await _countryMongoService.GetById(id);
        return country is null ? NotFound(): Ok(country);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateOrUpdateCountryDTO createOrUpdateCountryDTO) {
        if (ModelState.IsValid)
        {
            Country country = new(
                "",
                createOrUpdateCountryDTO.Name,
                createOrUpdateCountryDTO.Population,
                createOrUpdateCountryDTO.LandArea,
                createOrUpdateCountryDTO.Density
            );
            await _countryMongoService.Add(country);
            return CreatedAtAction(nameof(Add),country);
        }
        return BadRequest();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _countryMongoService.Delete(id);
        return NoContent();
    }
    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update(string id,[FromBody] CreateOrUpdateCountryDTO createOrUpdateCountryDTO) {
        if(ModelState.IsValid) {
            Country country = new(
                id,
                createOrUpdateCountryDTO.Name,
                createOrUpdateCountryDTO.Population,
                createOrUpdateCountryDTO.LandArea,
                createOrUpdateCountryDTO.Density
            );
            await _countryMongoService.Update(country);
        return NoContent();
        }
        return BadRequest();
    }
}
