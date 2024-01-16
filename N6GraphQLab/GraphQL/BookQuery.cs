namespace N6GraphQLab.GraphQL;

[ExtendObjectType(nameof(Query))]
public class BookQuery
{
  readonly Book[] _books = new Book[]
  {
    new("I Love GraphQL", new Author("Brandon Minnick")),
    new("GraphQL is the Future", new Author("Brandon Minnick")),
    new("I Love SOAP + XML", new Author("John 'I Hate New Technology' Joe")),
    new("C# in depth.", new Author("Jon Skeet")),
    new("Python 在財務與會計上的應用", new Author("莊泉福")),
    new("微服務開發指南|使用Spring Cloud與Docker ", new Author("曾瑞君")),
    new("Python零基礎入門班(第四版)", new Author("文淵閣工作室")),
    new("Azure DevOps 設計策略與實戰分析：開發工程師從入門到進階完全指南(iThome鐵人賽系列書)", new Author("范明城")),
    new("圖解資料結構 × 演算法：運用 C 語言結合 ChatGPT 輔助驗證及寫程式", new Author("胡昭民")),
    new("Python範例學習書|輕鬆、有趣學習Python程式設計", new Author("吳進北")),
  };

  [UseFiltering]
  public Book[] GetBookList() => _books;

  [UseFiltering]
  public IQueryable<Book> GetBookListX(string title) => _books.Where(c => c.Title.Contains(title)).AsQueryable();

  public Book? GetBook(string title) => _books.FirstOrDefault(c => c.Title.Contains(title));

  public Author? GetAuthor(string name) => _books.Where(c => c.Author.Name.Contains(name)).FirstOrDefault()?.Author;
}

public record Book(string Title, Author Author);

public record Author(string Name);
