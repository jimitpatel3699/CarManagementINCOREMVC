using JimitpatelZplusSolutionTest.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JimitpatelZplusSolutionTest.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public CarBrand Brand { get; set; }
        [Required]
        public CarClass Class { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z0-9]{10}$", ErrorMessage = "Model Code must be 10 alphanumeric characters.")]
        public string ModelCode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfManufacturing { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Sort order must be a positive integer.")]
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
