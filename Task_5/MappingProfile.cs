using AutoMapper;
using Task_5.Models;
using Task_5.Tables;

namespace Task_5
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeModel>()
            .ForMember(dest => dest.cityName, src => src.MapFrom(b => b.city.cityName))
            .ForMember(dest => dest.salaryDate, src => src.MapFrom(b => b.Transactions.Select(t => t.salaryDate).FirstOrDefault()));
        }
    }
}
