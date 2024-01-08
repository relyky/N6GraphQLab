using N6GraphQLab.Services;

namespace N6GraphQLab.GraphQL;

[ExtendObjectType(nameof(Query))]
public class ProductQuery
{
  readonly ProductService _bizSvc;

  public ProductQuery([Service]IServiceProvider provider)
  {
    _bizSvc = provider.GetRequiredService<ProductService>();
  }

  public Product[] GetProductList() => _bizSvc.QueryProducts().ToArray();
}
