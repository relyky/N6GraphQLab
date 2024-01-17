namespace N6GraphQLab.GraphQL;

///
/// GraphQL Unions Lab
/// ref→[GraphQL Unions](https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/unions/)
///


[UnionType("PostContent")]
public interface IPostContent
{
}

public class TextContent : IPostContent
{
  public string Text { get; set; } = string.Empty;
}

public class ImageContent : IPostContent
{
  public string ImageUrl { get; set; } = string.Empty;

  public int Height { get; set; }
}
