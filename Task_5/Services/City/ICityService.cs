namespace Task_5.Services.City
{
    public interface ICityService
    {
        Task<Tables.City> GetCityByIdAsync(int cityId);
        Task<List<Tables.City>> GetAllCitiesAsync();
        Task<Tables.City> AddCityAsync(Tables.City city);
        Task UpdateCityAsync(int cityId, Tables.City updatedCity);
        Task DeleteCityAsync(int cityId);
    }
}
