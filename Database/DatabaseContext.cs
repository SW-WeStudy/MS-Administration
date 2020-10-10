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
        
        public DbSet<Course> course { get; set; }
        public DbSet<User_Course> user_course { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server= westudydb.ce9xg8lh3vrl.us-east-2.rds.amazonaws.com;userid= root;password=Luis99.06;Database=westudydb; ");
        }
        public List<User_Course> ObtainAdmins(int CId)
        {
            List<User_Course> admins = user_course.Where(usr => ((usr.id_course == CId) && (usr.rol.Equals("Admin")))).ToList();
            return admins;
        }
        public void UpdateUser(String UId, int CId, String rol)
        {
            var user = user_course.First(i => ((i.id_course == CId) && (i.id_user.Equals(UId))));
            user_course.Single(usr => usr.id_user_course == user.id_user_course).rol = rol;
            SaveChanges();
        }
        public void AddUserCourse(User_Course newUser)
        {
            user_course.Add(newUser);
            SaveChanges();
        }
    }
}
