namespace N6GraphQLab.GraphQL;

public record Book(string Title, Author Author);

public record Author(string Name);

[ExtendObjectType(nameof(Query))]
public class BookQuery
{
  readonly Book[] _books = new Book[]
  {
    new("I Love GraphQL", new Author("Brandon Minnick")),
    new("GraphQL is the Future", new Author("Brandon Minnick")),
    new("I Love SOAP + XML", new Author("John 'I Hate New Technology' Joe")),
    new("C# in depth.", new Author("Jon Skeet")),
  };

  public Book[] GetBookList() => _books;

  public Book? GetBook(string title) => _books.FirstOrDefault(c => c.Title.Contains(title));

  public Author? GetAuthor(string name) => _books.Where(c => c.Author.Name.Contains(name))
                                                 .FirstOrDefault()?.Author;
}
