using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UdemySwagger2.Models
{/// <summary>
/// Ürün ensnesi
/// </summary>
    public partial class Product
    {/// <summary>
    /// Ürün id'si
    /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Ürün ismi
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Ürün fiyatı
        /// </summary>
        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// Ürün eklenme tarihi
        /// </summary>
        public DateTime? Date { get; set; }
        public string Category { get; set; }
    }
}
