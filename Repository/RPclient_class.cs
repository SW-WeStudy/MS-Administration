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
            new Course() { id_course = 1, name = "Test101", forum = "This is just a test"}
        };
        public static List<User_Course> _UserCourseList = new List<User_Course>()
        {
            new User_Course() {id_course = 1, state = "Lo que sea", id_user_course = 1, id_user = 1, rol = "Admin"},
            new User_Course() {id_course = 1, state = "Hola", id_user_course = 2, id_user = 2, rol = "User"},
            new User_Course() {id_course = 1, state = "Lo que sea 2", id_user_course = 3, id_user = 3, rol = "Admin"}
        };

        public List<User_Course> ObtainAdmins(int CId)
        {
            List<User_Course> admins = _UserCourseList.Where(usr => ((usr.id_course == CId) && (usr.rol.Equals("Admin")))).ToList();
            return admins;
        }
        public void UpdateUser(int UId, int CId, String rol)
        {
            var user = _UserCourseList.First(i => (i.id_user == UId) && (i.id_course == CId));
            _UserCourseList.Find(u => u.id_user_course == user.id_user_course).rol = rol;
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
