using Microsoft.AspNetCore.Mvc;
using tpModul10_103022300110.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tpModul10_103022300110.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> listMahasiswa = new List<Mahasiswa>();

        // GET: api/Mahasiswa/getMahasiwa
        [HttpGet("getMahasiwa")]
        public IActionResult Get()
        {
            if (listMahasiswa.Count == 0)
            {
                return Ok(new { message = "Tidak ada data Mahasiswa" });
            }

            return Ok(listMahasiswa);
        }

        // GET api/Mahasiswa/getMahasiwa/5
        [HttpGet("getMahasiwa/{id}")]
        public ActionResult<Mahasiswa> Get(int id)
        {
            if (id < 0 || id >= listMahasiswa.Count)
            {
                return NotFound(new { message = "Data tidak ditemukan" });
            }

            return Ok(listMahasiswa[id]);
        }

        // POST api/Mahasiswa/createMahasiswa
        [HttpPost("createMahasiswa")]
        public ActionResult Post([FromForm] Mahasiswa request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Data Mahasiswa tidak boleh kosong" });
            }

            listMahasiswa.Add(request);

            return Ok(new { message = "Request Terkirim", data = request });
        }

        // PUT api/Mahasiswa/updateMahasiswa/5
        [HttpPut("updateMahasiswa/{id}")]
        public IActionResult Put(int id, [FromForm] Mahasiswa value)
        {
            if (id < 0 || id >= listMahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan" });
            }

            listMahasiswa[id] = value;
            return Ok(new { message = "Mahasiswa updated", data = value });
        }

        // DELETE api/Mahasiswa/deleteMahasiswa/5
        [HttpDelete("deleteMahasiswa/{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= listMahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan" });
            }

            listMahasiswa.RemoveAt(id);
            return Ok(new { message = "Mahasiswa deleted" });
        }
    }
}
