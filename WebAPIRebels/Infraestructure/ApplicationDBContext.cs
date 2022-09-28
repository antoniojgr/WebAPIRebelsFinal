using Microsoft.EntityFrameworkCore;
using WebAPIRebels.Domain.Entities;

namespace WebAPIRebels.Infraestructure
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RebelEntity> Rebels { get; set; }


    }
}
