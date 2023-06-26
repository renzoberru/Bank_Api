using BaseDatos.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BaseDatos.DBContext
{
    public class BancoDbContext : DbContext
    {
        public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options)
        {
        }
        public DbSet<Banco> Banco { get; set; }
    }
}
