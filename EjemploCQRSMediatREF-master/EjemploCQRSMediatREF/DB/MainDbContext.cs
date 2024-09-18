using EjemploCQRSMediatREF.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace EjemploCQRSMediatREF.DB
{
    public class MainDbContext:DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
        public DbSet<Producto> Productos { get; set; }
    }
}
