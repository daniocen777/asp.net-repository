using Microsoft.EntityFrameworkCore;
using Shooping.Data.Entities;

namespace Shooping.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }

        // add-migration [DescriptionCamelCase] => Para la modificacion o creacion de atributos de las tablas
        // update-database => Creaar la BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Crear index para que nombre de pais sea unico
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
