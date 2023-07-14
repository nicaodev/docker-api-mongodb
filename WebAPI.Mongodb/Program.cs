using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Mongodb.Data;
using WebAPI.Mongodb.Data.SQLSERVERContext;
using WebAPI.Mongodb.Repository;
using WebAPI.Mongodb.Repository.Basket;
using WebAPI.Mongodb.Repository.Pessoa;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SQLSERVERContext>(opt => opt.UseSqlServer(connection));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductAPI", Version = "v1" });
});

// docker run --name local-redis -p 6379:6379 -d redis

builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

builder.Services.AddScoped<IProductContext, ProductContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Subir os  containers e override de configs.

//docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductAPI v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();