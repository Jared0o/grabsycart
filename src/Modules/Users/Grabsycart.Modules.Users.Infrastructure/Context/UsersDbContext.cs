using Grabsycart.Modules.Users.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grabsycart.Modules.Users.Infrastructure.Context;

public class UsersDbContext : IdentityDbContext<User, Role, Guid>
{
    public UsersDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.HasDefaultSchema("Users");
    }
}