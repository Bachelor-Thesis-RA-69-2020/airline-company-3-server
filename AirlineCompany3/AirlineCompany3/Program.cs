using AirlineCompany3.Repository.DatabaseContext;
using AirlineCompany3.Repository.Interface;
using AirlineCompany3.Repository;
using AirlineCompany3.Service.Interface;
using AirlineCompany3.Service;
using AirlineCompany3.Resolver.Query;
using AirlineCompany3.Resolver.Type;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ServerDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IAirportService, AirportService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddGraphQLServer()
                .AddQueryType<AirportQuery>()
                .AddType<AirportType>();

var app = builder.Build();

app.MapGraphQL();
app.MapGraphQLHttp();
app.MapGraphQLSchema();

string host = builder.Configuration["Host"];
string port = builder.Configuration["Port"];
app.Run($"http://{host}:{port}");

