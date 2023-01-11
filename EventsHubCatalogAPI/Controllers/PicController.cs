using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsHubCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : ControllerBase
    {

        private readonly IWebHostEnvironment _env;
        public PicController(IWebHostEnvironment env)
        {
            _env = env;
        }
        [HttpGet("{id}")]

        public IActionResult GetImage(int id)
        {
            var webRoot = _env.WebRootPath.Replace('\\','/');
            var path = Path.Combine($"{webRoot}/Pics/", $"event{id}.jpeg");
            var buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "image/jpeg");
        }
    }
}
