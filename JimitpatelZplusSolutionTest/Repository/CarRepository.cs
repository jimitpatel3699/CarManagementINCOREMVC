using AutoMapper;
using JimitpatelZplusSolutionTest.Data;
using JimitpatelZplusSolutionTest.Models;
using JimitpatelZplusSolutionTest.ViewModel;

namespace JimitpatelZplusSolutionTest.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public CarRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<CarCreateVM> Search(string search)
        {
            var cars = _context.cars
                    .Where(model => model.ModelName.Contains(search) || model.ModelCode.Contains(search))
                    .ToList();

            var carvm = _mapper.Map<IEnumerable<CarCreateVM>>(cars);
            return carvm;
        }
        public IEnumerable<CarCreateVM> GetAll()
        {
            var car = _context.cars
                        .Where(x => x.IsDeleted == false)
                        .OrderByDescending(x => x.DateOfManufacturing)
                        .ThenBy(x => x.SortOrder)
                        .ToList();
            var carvm = _mapper.Map<IEnumerable<CarCreateVM>>(car);
            return carvm;
        }
        public CarCreateVM Get(int? id)
        {
            var car = _context.cars.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            var carvm = _mapper.Map<CarCreateVM>(car);
            return carvm;
        }
        public bool AddCar(CarCreateVM carvm)
        {
            if (carvm != null)
            {
                var car = _mapper.Map<Car>(carvm);
                _context.cars.Add(car);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateCar(CarCreateVM carvm)
        {
            if (carvm != null)
            {
                var car = _mapper.Map<Car>(carvm);
                _context.cars.Update(car);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteCar(int? id)
        {
            var car = _context.cars.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (car != null)
            {
                car.IsDeleted = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
