using BreweryWholesaleManagement.Business.Cms.Brewery;
using BreweryWholesaleManagement.Business.Cms.Wholesaler;
using BreweryWholesaleManagement.Data.Db;
using BreweryWholesaleManagement.Extension;
using CmsApi.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddMvc(options =>
{

    options.EnableEndpointRouting = false;
    options.Filters.Add(typeof(ModelValidationFilter)); // validate method parameter model state with dataAnnotation 
}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CmsApi API"
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    c.CustomSchemaIds(i => i.FullName);
});

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, HttpContextAccessor>(); 
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("DefaultConnection").Value));
builder.Services.AddTransient<IBreweryBusiness, BreweryBusiness>();
builder.Services.AddTransient<IWholesalerBusiness, WholesalerBusiness>();
//builder.Services.AddSingleton<MyDbContext>();

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

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
