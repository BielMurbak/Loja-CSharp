using MinhaApi.ExceptionHandlers;
using MinhaApi.Repositories;
using MinhaApi.Services;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Serviços da aplicação
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Constrói a aplicação
var app = builder.Build();

// Cria um escopo para usar serviços Scoped fora de uma requisição HTTP
using var scope = app.Services.CreateScope();

// Pega uma instância do AppDbContext
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

context.Database.EnsureCreated();

app.UseExceptionHandler();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();