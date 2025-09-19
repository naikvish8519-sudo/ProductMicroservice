using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.ProductsMicroService.API.APIEndpoints
{
    public static class PizzaMenuAPIEndpoints
    {
        public static IEndpointRouteBuilder MapPizzaMenuAPIEndpoints(this IEndpointRouteBuilder app)
        {
            // ======= PIZZAS =======

            app.MapGet("/api/pizzas", async ([FromServices] IPizzaMenuService pizzaMenuService) =>
            {
                var pizzas = await pizzaMenuService.GetPizzas();
                return Results.Ok(pizzas);
            });

            app.MapGet("/api/pizzas/{id:int}", async ([FromServices] IPizzaMenuService pizzaMenuService, int id) =>
            {
                var pizza = await pizzaMenuService.GetPizzaByCondition(p => p.Id == id);
                return pizza == null ? Results.NotFound() : Results.Ok(pizza);
            });

            app.MapPost("/api/pizzas", async (
                [FromServices] IPizzaMenuService pizzaMenuService,
                [FromBody] PizzaSizeAddRequest request) =>
            {
                var addedPizza = await pizzaMenuService.AddPizza(request);
                return addedPizza != null
                    ? Results.Created($"/api/pizzas/{addedPizza.Id}", addedPizza)
                    : Results.Problem("Error adding pizza");
            });

            app.MapPut("/api/pizzas", async (
                [FromServices] IPizzaMenuService pizzaMenuService,
                [FromBody] PizzaSizeUpdateRequest request) =>
            {
                var updatedPizza = await pizzaMenuService.UpdatePizza(request);
                return updatedPizza != null
                    ? Results.Ok(updatedPizza)
                    : Results.Problem("Error updating pizza");
            });

            app.MapDelete("/api/pizzas/{id:int}", async ([FromServices] IPizzaMenuService pizzaMenuService, int id) =>
            {
                var isDeleted = await pizzaMenuService.DeletePizza(id);
                return isDeleted ? Results.Ok(true) : Results.Problem("Error deleting pizza");
            });

            // ======= TOPPINGS =======

            app.MapGet("/api/toppings", async ([FromServices] IPizzaMenuService pizzaMenuService) =>
            {
                var toppings = await pizzaMenuService.GetToppings();
                return Results.Ok(toppings);
            });

            app.MapGet("/api/toppings/{id:int}", async ([FromServices] IPizzaMenuService pizzaMenuService, int id) =>
            {
                var topping = await pizzaMenuService.GetToppingByCondition(t => t.Id == id);
                return topping == null ? Results.NotFound() : Results.Ok(topping);
            });

            app.MapGet("/api/toppings/veg", async ([FromServices] IPizzaMenuService pizzaMenuService) =>
            {
                var toppings = await pizzaMenuService.GetVegToppings();
                return Results.Ok(toppings);
            });

            app.MapGet("/api/toppings/nonveg", async ([FromServices] IPizzaMenuService pizzaMenuService) =>
            {
                var toppings = await pizzaMenuService.GetNonVegToppings();
                return Results.Ok(toppings);
            });

            app.MapPost("/api/toppings", async (
                [FromServices] IPizzaMenuService pizzaMenuService,
                [FromBody] ToppingAddRequest request) =>
            {
                var addedTopping = await pizzaMenuService.AddTopping(request);
                return addedTopping != null
                    ? Results.Created($"/api/toppings/{addedTopping.Id}", addedTopping)
                    : Results.Problem("Error adding topping");
            });

            app.MapPut("/api/toppings", async (
                [FromServices] IPizzaMenuService pizzaMenuService,
                [FromBody] ToppingUpdateRequest request) =>
            {
                var updatedTopping = await pizzaMenuService.UpdateTopping(request);
                return updatedTopping != null
                    ? Results.Ok(updatedTopping)
                    : Results.Problem("Error updating topping");
            });

            app.MapDelete("/api/toppings/{id:int}", async ([FromServices] IPizzaMenuService pizzaMenuService, int id) =>
            {
                var isDeleted = await pizzaMenuService.DeleteTopping(id);
                return isDeleted ? Results.Ok(true) : Results.Problem("Error deleting topping");
            });

            return app;
        }
    }
}
