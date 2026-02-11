using Microsoft.EntityFrameworkCore;
using Archi.Library.Models;

namespace Archi.API.Data;

public class ArchiDbContext : DbContext
{
    public ArchiDbContext(DbContextOptions<ArchiDbContext> options) : base(options) { }

    public DbSet<TacosModel> Tacos { get; set; } = null!;
    public DbSet<PizzaModel> Pizzas { get; set; } = null!;
}
