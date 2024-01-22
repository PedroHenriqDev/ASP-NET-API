using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }   

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
