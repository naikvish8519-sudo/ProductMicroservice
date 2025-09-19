using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.BusinessLogicLayer.DTO
{
    public class PizzaSizeAddRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class PizzaSizeUpdateRequest
    {
        public int Id { get; set; }   // Matches PizzaSize.Id
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class PizzaSizeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    // ==== Topping DTOs ====
    public class ToppingAddRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsVeg { get; set; }
    }

    public class ToppingUpdateRequest
    {
        public int Id { get; set; }   // Matches Topping.Id
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsVeg { get; set; }
    }

    public class ToppingResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsVeg { get; set; }
    }
}
