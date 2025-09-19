using AutoMapper;
using DataAccessLayer.Entities;
using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.RepositoryContracts;
using System.Linq.Expressions;

namespace eCommerce.BusinessLogicLayer.Services
{
    public class PizzaMenuService : IPizzaMenuService
    {
        private readonly IPizzaMenuRepository _pizzaMenuRepository;
        private readonly IMapper _mapper;

        public PizzaMenuService(IPizzaMenuRepository pizzaMenuRepository, IMapper mapper)
        {
            _pizzaMenuRepository = pizzaMenuRepository;
            _mapper = mapper;
        }

        // ===== Pizza Methods =====
        public async Task<List<PizzaSizeResponse?>> GetPizzas()
        {
            var pizzas = await _pizzaMenuRepository.GetAllPizzasAsync();
            return _mapper.Map<List<PizzaSizeResponse>>(pizzas);
        }

        public async Task<PizzaSizeResponse?> GetPizzaByCondition(Expression<Func<PizzaSize, bool>> conditionExpression)
        {
            var pizza = (await _pizzaMenuRepository.GetAllPizzasAsync()).AsQueryable().FirstOrDefault(conditionExpression.Compile());
            return _mapper.Map<PizzaSizeResponse>(pizza);
        }

        public async Task<List<PizzaSizeResponse?>> GetPizzasByCondition(Expression<Func<PizzaSize, bool>> conditionExpression)
        {
            var pizzas = (await _pizzaMenuRepository.GetAllPizzasAsync()).AsQueryable().Where(conditionExpression.Compile());
            return _mapper.Map<List<PizzaSizeResponse>>(pizzas);
        }

        public async Task<PizzaSizeResponse?> AddPizza(PizzaSizeAddRequest pizzaAddRequest)
        {
            var pizza = _mapper.Map<PizzaSize>(pizzaAddRequest);
            var addedPizza = await _pizzaMenuRepository.AddPizzaAsync(pizza);
            return _mapper.Map<PizzaSizeResponse>(addedPizza);
        }

        public async Task<PizzaSizeResponse?> UpdatePizza(PizzaSizeUpdateRequest pizzaUpdateRequest)
        {
            var pizza = _mapper.Map<PizzaSize>(pizzaUpdateRequest);
            var updatedPizza = await _pizzaMenuRepository.UpdatePizzaAsync(pizza);
            return _mapper.Map<PizzaSizeResponse>(updatedPizza);
        }

        public async Task<bool> DeletePizza(int pizzaId)
        {
            return await _pizzaMenuRepository.DeletePizzaAsync(pizzaId);
        }

        // ===== Topping Methods =====
        public async Task<List<ToppingResponse?>> GetToppings()
        {
            var toppings = await _pizzaMenuRepository.GetAllToppingsAsync();
            return _mapper.Map<List<ToppingResponse>>(toppings);
        }

        public async Task<ToppingResponse?> GetToppingByCondition(Expression<Func<Topping, bool>> conditionExpression)
        {
            var topping = (await _pizzaMenuRepository.GetAllToppingsAsync()).AsQueryable().FirstOrDefault(conditionExpression.Compile());
            return _mapper.Map<ToppingResponse>(topping);
        }

        public async Task<List<ToppingResponse?>> GetToppingsByCondition(Expression<Func<Topping, bool>> conditionExpression)
        {
            var toppings = (await _pizzaMenuRepository.GetAllToppingsAsync()).AsQueryable().Where(conditionExpression.Compile());
            return _mapper.Map<List<ToppingResponse>>(toppings);
        }

        public async Task<ToppingResponse?> AddTopping(ToppingAddRequest toppingAddRequest)
        {
            var topping = _mapper.Map<Topping>(toppingAddRequest);
            var addedTopping = await _pizzaMenuRepository.AddToppingAsync(topping);
            return _mapper.Map<ToppingResponse>(addedTopping);
        }

        public async Task<ToppingResponse?> UpdateTopping(ToppingUpdateRequest toppingUpdateRequest)
        {
            var topping = _mapper.Map<Topping>(toppingUpdateRequest);
            var updatedTopping = await _pizzaMenuRepository.UpdateToppingAsync(topping);
            return _mapper.Map<ToppingResponse>(updatedTopping);
        }

        public async Task<bool> DeleteTopping(int toppingId)
        {
            return await _pizzaMenuRepository.DeleteToppingAsync(toppingId);
        }

        public async Task<List<ToppingResponse?>> GetVegToppings()
        {
            var toppings = await _pizzaMenuRepository.GetVegToppingsAsync();
            return _mapper.Map<List<ToppingResponse>>(toppings);
        }

        public async Task<List<ToppingResponse?>> GetNonVegToppings()
        {
            var toppings = await _pizzaMenuRepository.GetNonVegToppingsAsync();
            return _mapper.Map<List<ToppingResponse>>(toppings);
        }
    }
}
