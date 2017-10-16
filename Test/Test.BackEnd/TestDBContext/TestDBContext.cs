using System.Data.Entity;
using Test.Models.Entities;

namespace Test.BackEnd.TestDBContext
{
    public class TestDBContext : DbContext
    {
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Server> Servers { get; set; }
    }
}