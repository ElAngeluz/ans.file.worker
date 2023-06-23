using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ans.file.worker.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFile")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
