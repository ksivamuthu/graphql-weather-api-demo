using Gql;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services
    .AddDbContext<CityDbContext>();

builder.Services
    .AddHttpClient()
    .AddTransient<OpenWeatherService>();

var app = builder.Build();
app.UseRouting()
   .UseEndpoints(endpoints => endpoints.MapGraphQL());
       
app.MapGet("/", () => "Hello GraphQL!");
initializeDatabase(app);

app.Run();

void initializeDatabase(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<CityDbContext>();
        if (context.Database.EnsureCreated())
        {
            context.Cities.Add(new City { Name = "Seattle" });
            context.SaveChangesAsync();
        }
    }
}