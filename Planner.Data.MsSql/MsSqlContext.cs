using Microsoft.EntityFrameworkCore;

using Planner.Data.Models;

namespace Planner.Data.MsSql
{
    /// <summary>
    /// Todo: Install the following nuget packages
    /// Entity FrameworkCore
    /// Microsoft.EntityFrameworkCore.Tools
    /// Microsoft.EntityFrameworkCore.SqlServer
    /// 
    /// Tools -> Nuget Package manager -> Package manager console
    /// Create migration: add-migration #migration-name
    /// Update database: update-database
    /// 
    /// Install: Sql server (use localdb)
    /// Microsoft sql server management studio
    /// </summary>
    /// add-migration
    // update-database
    public class MsSqlContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Todo: set connection string
            // set database name
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Planner;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
