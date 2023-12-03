﻿using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Categoría")]
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Name { get; set; } = null!;
    }
}
