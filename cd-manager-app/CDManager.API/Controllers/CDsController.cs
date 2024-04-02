using Microsoft.AspNetCore.Mvc;
using CDManager.Domain.Interfaces;
using CDManager.Domain.Entities;

namespace CDManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CDsController : ControllerBase
    {
        private readonly ICDService _cdService;

        public CDsController(ICDService cdService)
        {
            _cdService = cdService;
        }

        [HttpPost]
        public ActionResult<CDMusic> Create(CDMusic cd)
        {
            var createdCD = _cdService.CreateCD(cd);
            return CreatedAtAction(nameof(Get), new { id = createdCD.Id }, createdCD);
        }

        [HttpGet]
        public ActionResult<List<CDMusic>> Get(string title, string artist, string genre, string musicName)
        {
            var cds = _cdService.GetCDs(title, artist, genre, musicName);
            return Ok(cds);
        }
    }
}
