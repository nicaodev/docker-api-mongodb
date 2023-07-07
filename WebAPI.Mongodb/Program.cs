using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Mongodb.Data;
using WebAPI.Mongodb.Data.SQLSERVERContext;
using WebAPI.Mongodb.Repository;
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

builder.Services.AddScoped<IProductContext, ProductContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Subir os 2 containers e override de configs.

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