namespace N6GraphQLab.GraphQL;

/// <summary>
/// GrqphQL query root
/// </summary>
public class Query
{
  public string Hello(string name = "World") => $"Hello, {name}! {DateTime.Now:HH:mm:ss}";
}
