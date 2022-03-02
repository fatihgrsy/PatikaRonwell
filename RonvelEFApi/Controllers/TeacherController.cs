using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RonvelEFApi.Controllers
{
    public class TeacherController : ApiController
    {
        Models.SchoolContext _context;
        public TeacherController()
        {
            if (_context == null)
                _context = new Models.SchoolContext();
        }

        [HttpPost]
        [Route("TeacherAddRange")]
        public IHttpActionResult TeacherAddRange([FromBody] List<Models.Teacher> model)
        {
            try
            {
                _context.Teachers.AddRange(model);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpPost]
        [Route("TeacherAdd")]
        public IHttpActionResult TeacherAdd([FromBody] Models.Teacher model)
        {
            try
            {
                _context.Teachers.Add(model);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpPut]
        [Route("TeacherUpdate")]
        public IHttpActionResult TeacherUpdate([FromBody] Models.Teacher model)
        {
            try
            {
                var data = _context.Teachers.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.TeacherNameSurname = model.TeacherNameSurname;
                    data.ClassRoomId = model.ClassRoomId;
                    data.Id= model.Id;
                    _context.SaveChanges();
                    return Ok("Başarılı");
                }
                else
                return Ok("null");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }



        [HttpDelete]
        [Route("TeacherRemove")]
        public IHttpActionResult TeacherRemove([FromBody] int Id)
        {
            try
            {
                var data = _context.Teachers.FirstOrDefault(x => x.Id ==Id);
                _context.Teachers.Remove(data);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpGet]
        [Route("GetTeacherIds")]
        public IHttpActionResult GetTeacherIds([FromUri] int id)
        {
            try
            {
                return Ok(_context.Teachers.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpGet]
        [Route("GetTeacherAll")]
        public IHttpActionResult GetTeacherAll()
        {
            try
            {
                return Ok(_context.Teachers.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }
    }
}
