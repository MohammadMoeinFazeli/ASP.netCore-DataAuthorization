using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAuthorization.DataBase.Entities;
using DataAuthorization.DataBase.Extentions;
using DataAuthorization.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAuthorization.DataBase
{
    public class AppDbContext : DbContext
    {
        private readonly string _userId;
        public AppDbContext(DbContextOptions<AppDbContext> options, IGetClaimsProvider userData)
            : base(options)
        {
            _userId = userData.UserId;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        public override int SaveChanges
            (bool acceptAllChangesOnSuccess)
        {
            this.MarkCreatedItemAsOwnedBy(_userId);
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasQueryFilter(x => x.OwnedBy == _userId);

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User
                {
                    Id = 1, FirstName = "moein", LastName = "fazeli", Username = "user1", Password = "1234"
                },
                new User
                {
                    Id = 2, FirstName = "hassan", LastName = "saeedi", Username = "user2", Password = "1234"
                }
            });
        }
    }
}