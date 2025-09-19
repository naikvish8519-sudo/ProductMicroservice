using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using eCommerce.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PizzaMenuRepository : IPizzaMenuRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PizzaMenuRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

       

        // ===== Pizzas =====
        public async Task<IEnumerable<PizzaSize>> GetAllPizzasAsync()
            => await _dbContext.PizzaSizes.ToListAsync();

        public async Task<PizzaSize?> GetPizzaByIdAsync(int id)
            => await _dbContext.PizzaSizes.FindAsync(id);

        public async Task<PizzaSize?> GetPizzaByNameAsync(string name)
            => await _dbContext.PizzaSizes.FirstOrDefaultAsync(p => p.Name == name);

        public async Task<PizzaSize> AddPizzaAsync(PizzaSize pizza)
        {
            _dbContext.PizzaSizes.Add(pizza);
            await _dbContext.SaveChangesAsync();
            return pizza;
        }

        public async Task<PizzaSize> UpdatePizzaAsync(PizzaSize pizza)
        {
            _dbContext.PizzaSizes.Update(pizza);
            await _dbContext.SaveChangesAsync();
            return pizza;
        }

        public async Task<bool> DeletePizzaAsync(int id)
        {
            var pizza = await _dbContext.PizzaSizes.FindAsync(id);
            if (pizza == null) return false;

            _dbContext.PizzaSizes.Remove(pizza);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        // ===== Toppings =====
        public async Task<IEnumerable<Topping>> GetAllToppingsAsync()
            => await _dbContext.Toppings.ToListAsync();

        public async Task<Topping?> GetToppingByIdAsync(int id)
            => await _dbContext.Toppings.FindAsync(id);

        public async Task<Topping> AddToppingAsync(Topping topping)
        {
            _dbContext.Toppings.Add(topping);
            await _dbContext.SaveChangesAsync();
            return topping;
        }

        public async Task<Topping> UpdateToppingAsync(Topping topping)
        {
            _dbContext.Toppings.Update(topping);
            await _dbContext.SaveChangesAsync();
            return topping;
        }

        public async Task<bool> DeleteToppingAsync(int id)
        {
            var topping = await _dbContext.Toppings.FindAsync(id);
            if (topping == null) return false;

            _dbContext.Toppings.Remove(topping);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        // Extra queries
        public async Task<IEnumerable<Topping>> GetVegToppingsAsync()
            => await _dbContext.Toppings.Where(t => t.IsVeg).ToListAsync();

        public async Task<IEnumerable<Topping>> GetNonVegToppingsAsync()
            => await _dbContext.Toppings.Where(t => !t.IsVeg).ToListAsync();
    }
}
