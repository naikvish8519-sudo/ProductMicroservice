using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Topping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }         // Matches SQL identity column

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;   // e.g., Tomatoes, Pepperoni

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }  // e.g., 1.00, 1.50, etc.

        [Required]
        public bool IsVeg { get; set; }     // true = Veg, false = Non-Veg
    }
}
