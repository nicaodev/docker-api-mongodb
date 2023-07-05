using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using WebAPI.Mongodb.Model;

namespace WebAPI.Mongodb.Data;

public class ProductContext : IProductContext
{
    public ProductContext(IConfiguration config)
    {
        var client = new MongoClient(config.GetValue<string>
              ("DatabaseSettings:ConnectionString"));

        var database = client.GetDatabase(config.GetValue<string>
        ("DatabaseSettings:DatabaseName"));

        Products = database.GetCollection<Product>(config.GetValue<string>
          ("DatabaseSettings:CollectionName"));

        ProductContextSeed.SeedData(Products);
    }

    public IMongoCollection<Product> Products { get; }
}