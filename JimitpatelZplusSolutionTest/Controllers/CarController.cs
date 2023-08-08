using JimitpatelZplusSolutionTest.Enums;
using JimitpatelZplusSolutionTest.Repository;
using JimitpatelZplusSolutionTest.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JimitpatelZplusSolutionTest.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IWebHostEnvironment _webhostenvironment;
        public CarController(ICarRepository carRepository, IWebHostEnvironment webHostEnvironment)
        {
            _carRepository = carRepository;
            _webhostenvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var cars = _carRepository.GetAll();
            return View(cars);
        }
        public IActionResult Create(int? id)
        {
            ViewBag.Class = GetClass();
            ViewBag.Brand = GetBrand();
            if (id != null)
            {
                var cars = _carRepository.Get(id);
                return View(cars);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(CarCreateVM cardtl, IFormFile? file)
        {
            long maxFileSizeInBytes = 5 * 1024 * 1024;
            if (file != null && file.Length > maxFileSizeInBytes)
            {
                ModelState.AddModelError("file", "File size exceeds the maximum allowed (5MB).");
                return View(cardtl);
            }
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webhostenvironment.WebRootPath;
                try
                {
                    if (cardtl.Id != 0)
                    {
                        if (file != null)
                        {
                            string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            string productpath = Path.Combine(wwwRootPath, "Images", "Car");
                            if (!string.IsNullOrEmpty(cardtl.ImageUrl))
                            {
                                //delete old image
                                var oldImagePath = Path.Combine(wwwRootPath, cardtl.ImageUrl.TrimStart('\\'));
                                if (System.IO.File.Exists(oldImagePath))
                                {
                                    System.IO.File.Delete(oldImagePath);
                                }
                            }
                            using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                            {
                                file.CopyTo(fileStream);
                            }
                            cardtl.ImageUrl = @"\Images\Car\" + filename;
                        }
                        _carRepository.UpdateCar(cardtl);
                    }
                    else
                    {
                        if (file != null)
                        {

                            string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            string productpath = Path.Combine(wwwRootPath, "Images", "Car");
                            using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                            {
                                file.CopyTo(fileStream);
                            }
                            cardtl.ImageUrl = @"\Images\Car\" + filename;
                        }
                        else
                        {
                            cardtl.ImageUrl = @"\Images\Car\037158bc-8baf-4e57-887d-a5cffa17a5a0.jpg";

                        }
                        _carRepository.AddCar(cardtl);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex;
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }

        }
        public IActionResult Delete(int? id)
        {
            _carRepository.DeleteCar(id);
            return RedirectToAction("Index");
        }
        public IActionResult SearchCar(string search)
        {
            if (string.IsNullOrEmpty(search) == false)
            {
                var car = _carRepository.Search(search);
                return PartialView("_Search", car);
            }
            else
            {
                var car = _carRepository.GetAll();
                return PartialView("_Search", car);
            }
        }
        [NonAction]
        private IEnumerable<SelectListItem> GetClass()
        {
            IEnumerable<SelectListItem> CategoryList = Enum.GetValues(typeof(CarClass)).Cast<CarClass>().Select(u => new SelectListItem
            {
                Text = u.ToString(),
                Value = u.ToString()
            });
            return CategoryList;
        }

        [NonAction]
        private IEnumerable<SelectListItem> GetBrand()
        {
            IEnumerable<SelectListItem> CategoryList = Enum.GetValues(typeof(CarBrand)).Cast<CarBrand>().Select(u => new SelectListItem
            {
                Text = u.ToString(),
                Value = u.ToString()
            });
            return CategoryList;
        }
    }

}
