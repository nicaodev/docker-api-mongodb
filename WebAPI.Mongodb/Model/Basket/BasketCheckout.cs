namespace WebAPI.Mongodb.Model.Basket;

public class BasketCheckout
{
    public string UserName { get; set; }
    public decimal TotalPrice { get; set; }

    // adress

    public string Adress { get; set; }

    // payment

    public string CardNumber { get; set; }
}
