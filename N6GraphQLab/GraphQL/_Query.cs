namespace N6GraphQLab.GraphQL;

/// <summary>
/// GrqphQL query root
/// </summary>
public class Query
{
  public string Hello(string name = "World") => $"Hello, {name}! {DateTime.Now:HH:mm:ss}";

  /// <summary>
  /// 進階應用: GraphQL unions
  /// </summary>
  public List<IPostContent> GetMyUnionContent()
  {
    List<IPostContent> result = new();
    result.Add(new TextContent { Text = "我是文字內容。" });
    result.Add(new ImageContent { Height = 90, ImageUrl = "/images/not_exists.img" });
    result.Add(new TextContent { Text = "我是文字內容三" });

    return result;
  }
}
