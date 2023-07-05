using MongoDB.Driver;
using WebAPI.Mongodb.Model;

namespace WebAPI.Mongodb.Data;

public class ProductContextSeed
{
    public static void SeedData(IMongoCollection<Product> productColletion)
    {
        bool existProduct = productColletion.Find(p => true).Any();
        if (!existProduct)
        {
            productColletion.InsertManyAsync(GetMyProducts());
        }
    }

    private static IEnumerable<Product> GetMyProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Id = "64a5b5a5d530360bb4191250",
                Name = "Celular",
                Category = "High",
                Description = "Iphone",
                Image = "iphone.jpg"
            },
            new Product()
            {
                Id = "64a5b5a5d530360bb4191251",
                Name = "Celular",
                Category = "High",
                Description = "Xiaomi",
                Image = "Xiaomi.jpg"
            },
            new Product()
            {
                Id = "64a5b5a5d530360bb4191252",
                Name = "Celular",
                Category = "High",
                Description = "Samsung",
                Image = "Samsung.jpg"
            },
        };
    }
}