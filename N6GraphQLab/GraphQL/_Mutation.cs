using N6GraphQLab.Services;

namespace N6GraphQLab.GraphQL;

public record ProductAddedPayload(bool IsSuccess, Product NewProduct);
public record ProductInput(string Name, int Quantity);

public class Mutation
{
  readonly ProductService _bizSvc;

  public Mutation([Service] IServiceProvider provider)
  {
    _bizSvc = provider.GetRequiredService<ProductService>();
  }

  public Task<ProductAddedPayload> AddProdcut(ProductInput input)
  {
    var product = _bizSvc.AddProduct(new Product(0, input.Name, input.Quantity));
    return Task.FromResult(new ProductAddedPayload(true, product));
  }
}
