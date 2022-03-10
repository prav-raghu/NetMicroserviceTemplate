using Microsoft.EntityFrameworkCore;
using NetMicroserviceTemplate.Data.Entities;

namespace NetMicroserviceTemplate.Data;

public class UserDbContext: DbContext{
    public UserDbContext(DbContextOptions<UserDbContext> options):base(options){}

    public DbSet<User> User { get; set; }
}

