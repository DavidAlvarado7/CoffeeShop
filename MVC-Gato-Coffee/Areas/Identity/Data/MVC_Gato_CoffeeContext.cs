using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Gato_Coffee.Models;

namespace MVC_Gato_Coffee.Data;

public class MVC_Gato_CoffeeContext : IdentityDbContext<IdentityUser>
{
    public MVC_Gato_CoffeeContext(DbContextOptions<MVC_Gato_CoffeeContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<MVC_Gato_Coffee.Models.Account> Account { get; set; } = default!;
}
