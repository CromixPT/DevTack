using DevTrack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly ILogger<PackagesController> _logger;

        private readonly List<Package> _packages = new List<Package>{
                new Package("Package 1", 1.3M),
                new Package("Package 2", 1.1M)
            };

        public PackagesController(ILogger<PackagesController> logger)
        {
        }


        [HttpGet]
        public IActionResult GetAllPackages()
        {
            return Ok(_packages);
        }


        [HttpGet("{code}")]
        public IActionResult GetPackageByCode(Guid code)
        {
            return Ok(new Package("Package 1", 1.3M));
        }

        [HttpPost]
        public IActionResult Post(Package package)
        {
            return NoContent();
        }

        [HttpPost("{code}/update")]
        public IActionResult Post(Guid code)
        {
            return NoContent();
        }

    }

}