using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace westudy_administration_webapi_csharp.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
