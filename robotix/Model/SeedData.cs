using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace robotix.Model
{
    public static class SeedData
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>().HasData(new admin
            {
                Id = 1,
                Username = "manager",
                Password = "123456",
                LastLoginDate = DateTime.UtcNow
            });

        }
    }
}
