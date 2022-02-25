using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RonvelEFApi.Controllers
{
    public class SchoolController : ApiController
    {
        Models.SchoolContext _context;
        public SchoolController()
        {
            if(_context==null)
            _context = new Models.SchoolContext();
        }

        [HttpPost]
        [Route("SchoolAddRange")]
        public IHttpActionResult SchoolAddRange([FromBody] List<Models.School> model)
        {
            try
            {
                _context.Schools.AddRange(model);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }
        [HttpPost]
        [Route("SchoolAdd")]
        public IHttpActionResult SchoolAdd([FromBody] Models.School model)
        {
            try
            {
                _context.Schools.Add(model);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpPut]
        [Route("SchoolUpdate")]
        public IHttpActionResult SchoolUpdate([FromBody] Models.School model)
        {
            try
            {
                var data = _context.Schools.FirstOrDefault(x => x.Id == model.Id);
                data.SchoolAdress = model.SchoolAdress;
                data.SchoolName = model.SchoolName;
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpDelete]
        [Route("SchoolRemove")]
        public IHttpActionResult SchoolRemove([FromBody] int id )
        {
            try
            {
                var data = _context.Schools.FirstOrDefault(x => x.Id ==id);
                _context.Schools.Remove(data);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpGet]
        [Route("GetSchoolIds")]
        public IHttpActionResult GetSchoolIds([FromUri] int id)
        {
            try
            {
                return Ok(_context.Schools.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpGet]
        [Route("GetSchoolAll")]
        public IHttpActionResult GetSchoolAll()
        {
            try
            {
                return Ok(_context.Schools.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

    }
}
