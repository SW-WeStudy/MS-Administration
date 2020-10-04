using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace westudy_administration_webapi_csharp.Database.Entities
{
    public class User_Course
    {
        [Key]
        public int id_user_course { get; set; }
        public int id_user { get; set; }
        public int id_course { get; set; }
        public string rol { get; set; }
        public string state { get; set; }
    }
}
