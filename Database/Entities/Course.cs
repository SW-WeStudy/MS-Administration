using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace westudy_administration_webapi_csharp.Database.Entities
{
    public class Course
    {
        [Key]
        public int id_course { get; set; }
        public string name { get; set; }
        public string forum { get; set; }
    }
}
