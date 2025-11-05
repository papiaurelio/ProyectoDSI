using AppFinanzas.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppFinanzas.Data
{
    public class FinanzasDbContext : DbContext
    {
        private const string connectionString = "Host=localhost;Username=postgres;password=Aurelio444*;Database=AppFinanzas";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Prestamo> Prestamos { get; set; }
    }
}
