using HotChocolate.Subscriptions;
using N6GraphQLab.Services;

namespace N6GraphQLab.GraphQL;

public record ProductAddedPayload(bool IsSuccess, Product NewProduct);
public record ProductInput(string Name, int Quantity);

public class Mutation
{
  public async Task<ProductAddedPayload> AddProdcut(ProductInput input,
    [Service] IServiceProvider provider,
    [Service] ITopicEventSender eventSender)
  {
    var bizSvc = provider.GetRequiredService<ProductService>();

    var product = bizSvc.AddProduct(new Product(0, input.Name, input.Quantity));
    var result = new ProductAddedPayload(true, product);

    await eventSender.SendAsync(nameof(AddProdcut), result);
    // for subscription, 一般並不需要。 
    // mutation 通告：通告某 client 已有異動了。

    return result;
  }
}
