using BreweryWholesaleManagement.Data.Db;
using BreweryWholesaleManagement.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("DefaultConnection").Value));
if (Environment.OSVersion.Platform == PlatformID.Unix)
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(builder.Configuration.GetValue<int>("PortLinux"));  
                                                                                  
    });//linux
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCmsMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
