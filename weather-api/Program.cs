using Gql;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
        .AddQueryType<Query>();
var app = builder.Build();
app.UseRouting()
   .UseEndpoints(endpoints =>
       {
           endpoints.MapGraphQL();
       });
       
app.MapGet("/", () => "Hello GraphQL!");

app.Run();
