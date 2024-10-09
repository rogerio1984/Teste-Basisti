using Basisti_Client.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
//builder.Services.AddDbContext<AppDbContext>(option =>option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));>
builder.Services.AddDbContext<AppDbContext>(option =>option.UseSqlServer("name=ConnectionStrings:DefaultConnection"));


builder.Services.AddScoped<LivroRepository>();
builder.Services.AddScoped<AssuntoRepository>();
builder.Services.AddScoped<AutorRepository>();
builder.Services.AddScoped<LivroAssuntoRepository>();
builder.Services.AddScoped<LivroAutorRepository>();
builder.Services.AddScoped<LivroFormaCompraRepository>();



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
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();
