using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RonvelEFApi.Controllers
{
    public class ClassRoomController : ApiController
    {

        Models.SchoolContext _context;
        public ClassRoomController()
        {
            if (_context == null)
                _context = new Models.SchoolContext();
        }

        [HttpPost]
        [Route("ClassRoomRange")]
        public IHttpActionResult ClassRoomRange([FromBody] List<Models.ClassRoom> model)
        {
            try
            {
                _context.ClassRooms.AddRange(model);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }
        [HttpPost]
        [Route("ClassRoomAdd")]
        public IHttpActionResult ClassRoomAdd([FromBody] Models.ClassRoom model)
        {
            try
            {
                _context.ClassRooms.Add(model);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpPut]
        [Route("ClassRoomUpdate")]
        public IHttpActionResult ClassRoomUpdate([FromBody] Models.ClassRoom model)
        {
            try
            {
                var data = _context.ClassRooms.FirstOrDefault(x => x.Id == model.Id);
                data.ClassRoomName = model.ClassRoomName;
                data.SchoolId = model.SchoolId;
                data.Id = model.Id;
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpDelete]
        [Route("ClassRoomRemove")]
        public IHttpActionResult ClassRoomRemove([FromBody] int id)
        {
            try
            {
                var data = _context.ClassRooms.FirstOrDefault(x => x.Id == id);
                _context.ClassRooms.Remove(data);
                _context.SaveChanges();
                return Ok("Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpGet]
        [Route("GetClassRoomIds")]
        public IHttpActionResult GetClassRoomIds([FromUri] int id)
        {
            try
            {
                return Ok(_context.ClassRooms.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }

        [HttpGet]
        [Route("GetClassRoomAll")]
        public IHttpActionResult GetClassRoomAll()
        {
            try
            {
                return Ok(_context.ClassRooms.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest("Hatasız kul olmaz. Hatamla sev beni.");
            }
        }
    }
}
