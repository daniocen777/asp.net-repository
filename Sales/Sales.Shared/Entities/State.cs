using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Estado/Departamento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Name { get; set; } = null!;

        // Estado pertenece a un pais (Ir a Country y colocar la relacion - de los dos lados)
        public Country? Country { get; set; }

        // Estado tiene varias ciudades
        public ICollection<City>? Cities { get; set; }

        // Cantidad de ciudades en un estado (no se mapea en la BD)
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
