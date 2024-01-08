
namespace N6GraphQLab.Services;

public record Product(int Id, string Name, int Quantity);

internal class ProductService
{
  static List<Product> _products = new List<Product>
  {
      new(1,"Laptop",20),
      new(2,"Mouse",30),
      new(3,"Keyboard",10),
      new(4,"Monitor",40),
      new(5,"Main Frame",3),
  };

  public ProductService()
  {

  }

  public List<Product> QueryProducts()
  {
    return _products;
  }

}