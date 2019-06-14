using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Sandbox.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SandboxDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public SandboxDbContext(DbContextOptions<SandboxDbContext> options) : base(options)
        {
        }
    }
}
