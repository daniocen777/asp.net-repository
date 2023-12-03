
using Sales.Shared.Entities;

namespace Sales.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // esto crea la BD y la migra (en vez de realizarlo por comandos en consola) 
            await _context.Database.EnsureCreatedAsync();
            // Crear paises
            await CheckCountriesAsync();

            // Crear categorias
            await CheckCategoriesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add( new Category { Name = "Tecnología" } );
                _context.Categories.Add(new Category { Name = "Hogar" });
                _context.Categories.Add(new Category { Name = "Cocina" });
                _context.Categories.Add(new Category { Name = "Televisores" });
                _context.Categories.Add(new Category { Name = "Computadoras" });
                _context.Categories.Add(new Category { Name = "Electrodomésticos" });
                _context.Categories.Add(new Category { Name = "Videojuegos" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { Name = "Colombia" });
                _context.Countries.Add(new Country { Name = "Perú" });
                _context.Countries.Add(new Country { Name = "México" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
