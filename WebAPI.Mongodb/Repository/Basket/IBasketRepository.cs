using WebAPI.Mongodb.Model.Basket;

namespace WebAPI.Mongodb.Repository.Basket;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasket(string userName);

    Task<ShoppingCart> UpdateBasket(ShoppingCart basket);

    Task DeleteBasket(string userName);
}
