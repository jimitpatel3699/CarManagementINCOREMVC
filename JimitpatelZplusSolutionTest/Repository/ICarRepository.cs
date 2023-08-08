using JimitpatelZplusSolutionTest.ViewModel;

namespace JimitpatelZplusSolutionTest.Repository
{
    public interface ICarRepository
    {
        bool AddCar(CarCreateVM carvm);
        bool DeleteCar(int? id);
        CarCreateVM Get(int? id);
        IEnumerable<CarCreateVM> GetAll();
        IEnumerable<CarCreateVM> Search(string search);
        bool UpdateCar(CarCreateVM carvm);
    }
}