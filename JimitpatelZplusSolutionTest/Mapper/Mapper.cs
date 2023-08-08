using AutoMapper;
using JimitpatelZplusSolutionTest.Models;
using JimitpatelZplusSolutionTest.ViewModel;

namespace JimitpatelZplusSolutionTest.Mapper
{
    public class Mapper:Profile
    {
        public Mapper() 
        {
            CreateMap<Car,CarCreateVM>().ReverseMap();
        }
    }
}
