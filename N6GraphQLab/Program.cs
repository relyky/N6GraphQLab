using N6GraphQLab.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//## for GrqphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ProductQuery>()
    .AddType<BookQuery>()
    .AddSubscriptionType<Subscription>() // for GrqphQL subscriptions.
    .AddInMemorySubscriptions();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//## for GrqphQL
app.MapGraphQL();
app.UseWebSockets(); // for GrqphQL subscriptions.

app.Run();
