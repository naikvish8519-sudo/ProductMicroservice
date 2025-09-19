using DataAccessLayer.Entities;
using eCommerce.BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.BusinessLogicLayer.ServiceContracts
{
    public interface IPizzaMenuService
    {
        // ===== Pizza CRUD =====
        Task<List<PizzaSizeResponse?>> GetPizzas();
        Task<PizzaSizeResponse?> GetPizzaByCondition(Expression<Func<PizzaSize, bool>> conditionExpression);
        Task<List<PizzaSizeResponse?>> GetPizzasByCondition(Expression<Func<PizzaSize, bool>> conditionExpression);
        Task<PizzaSizeResponse?> AddPizza(PizzaSizeAddRequest pizzaAddRequest);
        Task<PizzaSizeResponse?> UpdatePizza(PizzaSizeUpdateRequest pizzaUpdateRequest);
        Task<bool> DeletePizza(int pizzaId);

        // ===== Topping CRUD =====
        Task<List<ToppingResponse?>> GetToppings();
        Task<ToppingResponse?> GetToppingByCondition(Expression<Func<Topping, bool>> conditionExpression);
        Task<List<ToppingResponse?>> GetToppingsByCondition(Expression<Func<Topping, bool>> conditionExpression);
        Task<ToppingResponse?> AddTopping(ToppingAddRequest toppingAddRequest);
        Task<ToppingResponse?> UpdateTopping(ToppingUpdateRequest toppingUpdateRequest);
        Task<bool> DeleteTopping(int toppingId);

        // ===== Extra Queries =====
        Task<List<ToppingResponse?>> GetVegToppings();
        Task<List<ToppingResponse?>> GetNonVegToppings();
    }
}
