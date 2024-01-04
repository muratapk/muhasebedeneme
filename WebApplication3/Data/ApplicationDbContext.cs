using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base()
        {
        }
    }
}
