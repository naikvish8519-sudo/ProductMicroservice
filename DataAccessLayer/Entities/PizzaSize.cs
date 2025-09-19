using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class PizzaSize
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }         // Matches SQL identity column

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;   // e.g., Small, Medium

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }  // e.g., 5.00, 7.00, etc.
    }
}
