namespace N6GraphQLab.Models;

public record Product(int Id, string Name, int Quantity);

public class ProductQuery
{
  readonly Product[] _products = new Product[]
  {
    new(1,"Laptop",20),
    new(2,"Mouse",30),
    new(3,"Keyboard",10),
    new(4,"Monitor",40),
  };

  public Product[] GetProductList() => _products;
}
