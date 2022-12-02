using Microsoft.EntityFrameworkCore;

namespace Note_Taking_App.DAL
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
