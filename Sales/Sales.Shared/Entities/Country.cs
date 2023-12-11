using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        // Data Annotation
        [Display(Name = "País")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Name { get; set; } = null!;

        // Pais tiene varios estados
        public ICollection<State>? States { get; set; }

        // Cantidad de estados en un pais (no se mapea en la BD)
        public int StatesNumber => States == null ? 0 : States.Count;
    }
}
