using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task3.Cash;

namespace Task_5.Services.City
{
    public class CityService: ICityService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICache _cache;

        public CityService(ApplicationDBContext context, IMapper mapper, ICache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Tables.City> GetCityByIdAsync(int cityId)
        {
            return await _context.City.FirstOrDefaultAsync(c => c.cityId == cityId);
        }

        public async Task<List<Tables.City>> GetAllCitiesAsync()
        {
            var data = _cache.Get("CityList");
            if (data == null)
                _cache.Add("CityList", _context.City.ToList());
            else
            {
                return (List<Tables.City>)data;
            }

            return await _context.City.ToListAsync();
        }

        public async Task<Tables.City> AddCityAsync(Tables.City city)
        {
            _context.City.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task UpdateCityAsync(int cityId, Tables.City updatedCity)
        {
            var existingCity = await _context.City.FirstOrDefaultAsync(c => c.cityId == cityId);
            if (existingCity != null)
            {
                existingCity.cityName = updatedCity.cityName;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCityAsync(int cityId)
        {
            var city = await _context.City.FirstOrDefaultAsync(c => c.cityId == cityId);
            if (city != null)
            {
                _context.City.Remove(city);
                await _context.SaveChangesAsync();
            }
        }
    }
}

