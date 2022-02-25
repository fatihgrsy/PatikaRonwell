using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RonvelEFApi.Controllers
{
    public class StudentController : ApiController
    {
        Models.SchoolContext _context;
        public StudentController()
        {
            if (_context == null)
                _context = new Models.SchoolContext();
        }

        [HttpPost]
        [Route("StudentAddRange")]
        public IHttpActionResult StudentAddRange([FromBody] List<Models.Student> model)
        {
            try
            {
                _context.Students.AddRange(model);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpPost]
        [Route("StudentAdd")]
        public IHttpActionResult StudentAdd([FromBody] Models.Student model)
        {
            try
            {
                _context.Students.Add(model);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpPut]
        [Route("StudentUpdate")]
        public IHttpActionResult StudentUpdate([FromBody] Models.Student model)
        {
            try
            {
                var data = _context.Students.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.StudentNameSurname = model.StudentNameSurname;
                    data.ClassRoomId = model.ClassRoomId;
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
        [Route("StudentRemove")]
        public IHttpActionResult StudentRemove([FromBody] int Id)
        {
            try
            {
                var data = _context.Students.FirstOrDefault(x => x.Id == Id);
                _context.Students.Remove(data);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpGet]
        [Route("GetStudentIds")]
        public IHttpActionResult GetStudentIds([FromUri] int id)
        {
            try
            {
                return Ok(_context.Students.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpGet]
        [Route("GetStudentAll")]
        public IHttpActionResult GetStudentAll()
        {
            try
            {
                return Ok(_context.Students.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }
    }
}
