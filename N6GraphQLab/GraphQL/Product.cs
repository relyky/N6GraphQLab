using N6GraphQLab.Services;

namespace N6GraphQLab.GraphQL;

[ExtendObjectType(nameof(Query))]
internal class ProductQuery
{
  readonly ProductService _bizSvc;

  public ProductQuery([Service]ProductService bizSvc)
  {
    _bizSvc = bizSvc;
  }

  public Product[] GetProductList() => _bizSvc.QueryProducts().ToArray();
}
