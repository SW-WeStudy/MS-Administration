using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using westudy_administration_webapi_csharp.Database.Entities;

namespace westudy_administration_webapi_csharp.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User_Course> User_Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=Jujpenabe\SqlExpress; initial catalog=UserMicroservice;persist security info=True;user id=sa;password=dotnettricks; ");
        }
    }
}
