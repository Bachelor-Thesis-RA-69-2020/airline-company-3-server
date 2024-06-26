using AirlineCompany3.Repository.DatabaseContext;
using AirlineCompany3.Repository.Interface;
using AirlineCompany3.Repository;
using AirlineCompany3.Service.Interface;
using AirlineCompany3.Service;
using AirlineCompany3.Resolver.Query;
using AirlineCompany3.Resolver.Type;
using Microsoft.EntityFrameworkCore;
using AirlineCompany3.Resolver.Mutation;
using AirlineCompany3.Repository.DataInitialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ServerDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();

builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddGraphQLServer()
                .AddQueryType<AirportQuery>()
                .AddType<AirportType>()
                .AddMutationType<FlightMutation>()
                .AddType<FlightCreationType>()
                .AddType<MessageType>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dbContext = services.GetRequiredService<ServerDatabaseContext>();

    var initializer = new AirportDataInitializer(dbContext);
    initializer.Initialize();
}

app.MapGraphQL();
app.MapGraphQLHttp();
app.MapGraphQLSchema();

string host = builder.Configuration["Host"];
string port = builder.Configuration["Port"];
app.Run($"http://{host}:{port}");

