using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MinhaApi.Entities;

namespace MinhaApi.Data;
public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Produto> Produtos {get; set;}
}