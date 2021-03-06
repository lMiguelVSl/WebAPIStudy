using Microsoft.EntityFrameworkCore;
using WebAPIStudy.Model;

namespace WebAPIStudy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Autor> Autores { get; set; }
    }
}
