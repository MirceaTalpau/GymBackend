using Microsoft.EntityFrameworkCore;
using Ogen.Models;

namespace Ogen.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options)
        {
            
        }
    }
}
