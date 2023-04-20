#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace LacTask1.Controllers;
// the MyContext class representing a session with our MySQL database, allowing us to query for or save data
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    public DbSet<Customer> Customers { get; set; }
}