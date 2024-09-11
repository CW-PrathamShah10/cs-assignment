using cswebapi.BAL;
using cswebapi.DAL;
using cswebapi.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();  // Ensure controllers are added
builder.Services.AddAutoMapper(typeof(MappingProfile)); 
builder.Services.AddScoped<IStockBAL, StockBAL>(); // Register BAL
builder.Services.AddScoped<IStockDAL, StockDAL>(); // Register DAL

builder.Services.AddAuthorization();  // Authorization services

// Swagger documentation
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

app.UseAuthorization(); // Ensure this is called after UseRouting and before MapControllers

app.MapControllers(); // Map controller endpoints

app.Run();
