using JimitpatelZplusSolutionTest.Models;
using Microsoft.EntityFrameworkCore;
using JimitpatelZplusSolutionTest.ViewModel;

namespace JimitpatelZplusSolutionTest.Data
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) { }
        public DbSet<Car> cars { get; set; }
    }
}
