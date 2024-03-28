using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Employee> Employees { get; set; }
}
