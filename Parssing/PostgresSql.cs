using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parssing
{
    class PostgresSql : DbContext
    {
        public DbSet<Forms> Forms { get; set; }
        //public PostgresSql()
        //{
        //    Database.EnsureCreated();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=192.168.4.188;Database=dseudb;Port=5432;User Id=postgres;Password=Password1");
        }
    }
}