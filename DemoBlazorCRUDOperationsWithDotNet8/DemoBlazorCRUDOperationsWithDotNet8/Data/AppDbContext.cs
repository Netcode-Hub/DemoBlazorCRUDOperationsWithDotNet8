using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace DemoBlazorCRUDOperationsWithDotNet8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product>  Products { get; set; }
    }
}
