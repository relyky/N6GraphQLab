using N6GraphQLab.GraphQL;
using N6GraphQLab.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//## for GrqphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ProductQuery>()
    .AddType<BookQuery>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>() // for GrqphQL subscriptions.
    .AddInMemorySubscriptions()
    .AddFiltering(); // enable filter

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//## ¦Û­qªA°È
builder.Services.AddScoped<ProductService>();

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
