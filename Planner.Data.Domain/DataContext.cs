using Microsoft.EntityFrameworkCore;
using System.IO;
using Planner.Data.Models;

namespace Planner.Data.Domain
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
    /// update-database
    /// or with command line
    /// dotnet ef migrations add InitialCreate --project Planner.Data.Domain
    /// dotnet ef database update -p Planner.WebApi/Planner.WebApi
    /// dotnet run -p Planner.WebApi/Planner.WebApi

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlite("Data Source=planner.db");

        public DbSet<User> Users { get; set; }

    }
}
