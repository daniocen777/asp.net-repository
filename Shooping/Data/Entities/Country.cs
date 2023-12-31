﻿using System.ComponentModel.DataAnnotations;

namespace Shooping.Data.Entities

// ctrl + k + f => Format 
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "País")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }
    }
}
