using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_5.Services.City;

namespace Task_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<Tables.City>> GetCityByIdAsync(int cityId)
        {
            var city = await _cityService.GetCityByIdAsync(cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpGet]
        public async Task<ActionResult<List<Tables.City>>> GetAllCitiesAsync()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpPost]
        public async Task<ActionResult<Tables.City>> AddCityAsync(Tables.City city)
        {
            var addedCity = await _cityService.AddCityAsync(city);
            return CreatedAtAction(nameof(GetCityByIdAsync), new { cityId = addedCity.cityId }, addedCity);
        }

        [HttpPut("{cityId}")]
        public async Task<IActionResult> UpdateCityAsync(int cityId, Tables.City updatedCity)
        {
            await _cityService.UpdateCityAsync(cityId, updatedCity);
            return NoContent();
        }

        [HttpDelete("{cityId}")]
        public async Task<IActionResult> DeleteCityAsync(int cityId)
        {
            await _cityService.DeleteCityAsync(cityId);
            return NoContent();
        }
    }
}