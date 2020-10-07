using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using westudy_administration_webapi_csharp.Database;
using westudy_administration_webapi_csharp.Database.Entities;

namespace westudy_administration_webapi_csharp.Controllers
{
    [Route("class/admin")]
    [ApiController]
    public class Admin : ControllerBase
    {
        private readonly DatabaseContext context;

        public Admin(DatabaseContext context)
        {
            this.context = context;
        }
        // GET api/values
        [HttpGet("courses")]
        public IActionResult GetCourses()
        {
            return Ok(context.course.ToList());
        }

        [HttpGet("usercourses")]
        public IActionResult GetUserCourses()
        {
            return Ok(context.user_course.ToList());
        }

        // GET admins of especified course id
        [HttpGet("getall/{id}")]
        public IActionResult Get(int id)
        {
            var ucRet = context.ObtainAdmins(id);

            if (ucRet.Count == 0)
            {                
                var nf = NotFound("No hay usuarios admin o el curso no existe.");
                return nf;
            }

            return Ok(ucRet);
        }

        // PUT api/values
        [HttpPut("setadmin")]
        public IActionResult addAdmin([FromBody] User_Course UCReg)
        {
            if (!UCReg.rol.Equals("Admin"))
            {           
                context.UpdateUser(UCReg.id_user, UCReg.id_course, "Admin");
                return Ok("Usuario actualizado: Ahora es admin");
            } else
            {
                return Conflict("El usuario ya es un Admin del Curso");
            }
                
        }
    /*
        // PUT api/values/5
        [HttpPut("add/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        } */

        // DELETE api/values/5
        [HttpPut("remove")]
        public IActionResult removeAdmin([FromBody] User_Course UCReg)
        {
            if (!UCReg.rol.Equals("User"))
            {
                context.UpdateUser(UCReg.id_user, UCReg.id_course, "User");
                return Ok("Usuario actualizado: Ahora es User");
            }
            else
            {
                return Conflict("Usuario ya es un User");
            }
        }
        [HttpPost("addnew")]
        public IActionResult AddUser(User_Course nUser)
        {
            context.AddUserCourse(nUser);
            return CreatedAtAction(nameof(AddUser), nUser);
        }
    }
}
