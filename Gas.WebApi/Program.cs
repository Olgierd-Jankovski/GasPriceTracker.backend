using Gas.Core;
using Gas.DB;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IStationServices, StationServices>();
builder.Services.AddTransient<ITypeServices, TypeServices>(); // type is a fuel type
builder.Services.AddTransient<ILocationServices, LocationServices>(); // location is a address
builder.Services.AddTransient<IPriceServices, PriceServices>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("TrackerPolicy",
        builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

// Add configuration
builder.Configuration.AddUserSecrets<Program>();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //   options.UseSqlServer(
    //            @"Server=(localdb)\mssqllocaldb;Database=GasDB;Trusted_Connection=True");
   var connectionString = builder.Configuration.GetConnectionString("AppDbContext");
    options.UseSqlServer(connectionString);
});

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

app.UseRouting();

// lets add a middleware to handle CORS
app.UseCors("TrackerPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
