using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoryContracts;
using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using eCommerce.BusinessLogicLayer.Services;
using eCommerce.ProductsMicroService.API.APIEndpoints;
using eCommerce.ProductsMicroService.API.Middleware;
using eCommerce.ProductsService.BusinessLogicLayer;
using eCommerce.ProductsService.DataAccessLayer;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

//Add DAL and BLL services
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();

// ✅ Register PizzaMenu services and repo explicitly
builder.Services.AddScoped<IPizzaMenuService, PizzaMenuService>();
builder.Services.AddScoped<IPizzaMenuRepository, PizzaMenuRepository>();

// ✅ Register FluentValidators
builder.Services.AddValidatorsFromAssemblyContaining<PizzaSizeAddRequest>();
builder.Services.AddValidatorsFromAssemblyContaining<ToppingAddRequest>();

// ✅ Register AutoMapper using mapping profile
builder.Services.AddAutoMapper(typeof(BusinessLogicLayer.Mappers.PizzaMenuMappingProfile));

builder.Services.AddControllers();

//FluentValidations
builder.Services.AddFluentValidationAutoValidation();

//Add model binder to read values from JSON to enum
builder.Services.ConfigureHttpJsonOptions(options => { 
  options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


//Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});



var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

//Cors
app.UseCors();

//Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // 👈 makes Swagger available at root
});


//Auth
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapProductAPIEndpoints();
app.MapPizzaMenuAPIEndpoints();

app.Run();
