using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoryContracts
{
    public interface IPizzaMenuRepository
    {
        // ===== Pizzas =====
        Task<IEnumerable<PizzaSize>> GetAllPizzasAsync();
        Task<PizzaSize?> GetPizzaByIdAsync(int id);
        Task<PizzaSize?> GetPizzaByNameAsync(string name);
        Task<PizzaSize> AddPizzaAsync(PizzaSize pizza);
        Task<PizzaSize> UpdatePizzaAsync(PizzaSize pizza);
        Task<bool> DeletePizzaAsync(int id);

        // ===== Toppings =====
        Task<IEnumerable<Topping>> GetAllToppingsAsync();
        Task<Topping?> GetToppingByIdAsync(int id);
        Task<Topping> AddToppingAsync(Topping topping);
        Task<Topping> UpdateToppingAsync(Topping topping);
        Task<bool> DeleteToppingAsync(int id);

        // Extra queries
        Task<IEnumerable<Topping>> GetVegToppingsAsync();
        Task<IEnumerable<Topping>> GetNonVegToppingsAsync();
    }
}
