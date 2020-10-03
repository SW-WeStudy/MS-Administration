using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using westudy_administration_webapi_csharp.Database.Entities;

namespace westudy_administration_webapi_csharp.Repository
{
    public class RPclient_class
    {
        public static List<User> _UserList = new List<User>()
        {
            new User() { Id = 1, Nombre = "Cliente 1" , Apellido = "Apellido 1" },
            new User() { Id = 2, Nombre = "Cliente 2" , Apellido = "Apellido 2" },
            new User() { Id = 3, Nombre = "Cliente 3" , Apellido = "Apellido 3" }
        };
        public static List<Course> _CourseList = new List<Course>()
        {
            new Course() { Id = 1, Nombre = "Test101", Forum = "This is just a test"}
        };
        public static List<User_Course> _UserCourseList = new List<User_Course>()
        {
            new User_Course() {CourseId = 1, Estado = "Lo que sea", Id = 1, UserId = 1, Rol = "Admin"},
            new User_Course() {CourseId = 1, Estado = "Hola", Id = 2, UserId = 2, Rol = "User"},
            new User_Course() {CourseId = 1, Estado = "Lo que sea 2", Id = 3, UserId = 3, Rol = "Admin"}
        };

        public List<User_Course> ObtainAdmins(int CId)
        {
            List<User_Course> admins = _UserCourseList.Where(usr => ((usr.CourseId == CId) && (usr.Rol.Equals("Admin")))).ToList();
            return admins;
        }
        public void UpdateUser(int UId, int CId, String rol)
        {
            var user = _UserCourseList.First(i => (i.UserId == UId) && (i.CourseId == CId));
            _UserCourseList.Find(u => u.Id == user.Id).Rol = rol;
        }
        public void Add(User newUser)
        {
            _UserList.Add(newUser);
        }
        public List<User_Course> AllUsers()
        {
            return _UserCourseList;
        }
    }
}
