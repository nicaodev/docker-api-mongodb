using MongoDB.Driver;
using WebAPI.Mongodb.Model;

namespace WebAPI.Mongodb.Data;

public interface IProductContext
{
    IMongoCollection<Product> Products { get; }
}