using Microsoft.AspNetCore.Mvc;
using Technical_Challenge.DAL;
using Technical_Challenge.Models.API;

namespace Technical_Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniversityController : Controller
    {
        #region Dependency Injection
        private readonly IUniversityDAL _universityDAL;
        public UniversityController(IUniversityDAL universityDAL)
        {
            _universityDAL = universityDAL;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetUniversityRequest req)
        {
            return Ok(await _universityDAL.GetList(req));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _universityDAL.Get(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUniversityRequest req)
        {
            return StatusCode(201, await _universityDAL.Create(req));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUniversityRequest req)
        {
            var result = await _universityDAL.Update(req);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _universityDAL.Delete(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost("bookmark/{id}")]
        public async Task<IActionResult> Bookmark(int id, [FromQuery] bool bookmark = true)
        {
            var u = await _universityDAL.Get(id);
            if (u == null)
                return NotFound();
            u.IsBookmark = bookmark;
            await _universityDAL.Update(u);
            return Ok(u);
        }
    }
}
