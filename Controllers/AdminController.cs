using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using westudy_administration_webapi_csharp.Database;
using westudy_administration_webapi_csharp.Database.Entities;
using westudy_administration_webapi_csharp.Repository;

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
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Users.ToList());
        }

        // GET api/values/5
        [HttpGet("getall/{id}")]
        public IActionResult Get(int id)
        {
            RPclient_class rpUC = new RPclient_class();

            var ucRet = rpUC.ObtainAdmins(id);

            if (ucRet.Count == 0)
            {                
                var nf = NotFound("No hay usuarios admin o el curso no existe.");
                return nf;
            }

            return Ok(ucRet);
        }

        // PUT api/values
        [HttpPut("add")]
        public IActionResult addAdmin([FromBody] User_Course UCReg)
        {
            if (!UCReg.Rol.Equals("Admin"))
            {
                RPclient_class rpUC = new RPclient_class();
                rpUC.UpdateUser(UCReg.UserId, UCReg.CourseId, "Admin");
                return Ok("Usuario actualizado: Ahora es admin");
            } else
            {
                return Conflict("El usuario ya es un Admin del Curso");
            }
                
        }

        // PUT api/values/5
        [HttpPut("add/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpPut("remove")]
        public IActionResult removeAdmin([FromBody] User_Course UCReg)
        {
            if (!UCReg.Rol.Equals("User"))
            {
                RPclient_class rpUC = new RPclient_class();
                rpUC.UpdateUser(UCReg.UserId, UCReg.CourseId, "User");
                return Ok("Usuario actualizado: Ahora es User");
            }
            else
            {
                return Conflict("Usuario ya es un User");
            }
        }
        [HttpPost("addnew")]
        public IActionResult AddUser(User nUser)
        {
            RPclient_class rpUC = new RPclient_class();
            rpUC.Add(nUser);
            return CreatedAtAction(nameof(AddUser), nUser);
        }
    }
}
