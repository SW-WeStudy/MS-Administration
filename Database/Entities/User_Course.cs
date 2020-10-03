using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace westudy_administration_webapi_csharp.Database.Entities
{
    public class User_Course
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
    }
}
