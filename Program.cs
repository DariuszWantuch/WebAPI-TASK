using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Repository;
using WebAPI.Data.Repository.IRepository;
using Newtonsoft.Json;
using WebAPI.Entities.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("TaskDB"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<CatalogConfiguration>();
builder.Services.AddScoped<ProductConfiguration>();

builder.Services.AddMvc()
    .AddNewtonsoftJson(
        options => {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var catalogConfiguration = scope.ServiceProvider.GetRequiredService<CatalogConfiguration>();
    var productConfiguration = scope.ServiceProvider.GetRequiredService<ProductConfiguration>();
    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

    catalogConfiguration.Initialize(unitOfWork);
    productConfiguration.Initialize(unitOfWork);
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();