using Microsoft.EntityFrameworkCore;
using System;
using TamroTask.Core.Entities;

namespace TamroTask.Infrastructure.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Dalius",
                    LastName = "Butrimas",
                    Email = "daliusbutrimas@outlook.com",
                    PhoneNumber = "+37062916834"
                },
                new User
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "JohnDoe@outlook.com",
                    PhoneNumber = "+37062911111"
                });
        }
    }
}
