using System.Net;
using DevTrack.Application.Features.DispatchPackage;
using DevTrack.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly ILogger<PackagesController> _logger;
        private readonly IMediator _mediator;

        private readonly List<Package> _packages = new List<Package>{
                new Package("Package 1", 1.3M),
                new Package("Package 2", 1.1M)
            };

        public PackagesController(ILogger<PackagesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
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
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DispatchPackage.Response), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody] DispatchPackage.Request request)
        {
            _logger.LogInformation("Incoming!");
            _mediator.Send(request);
            return NoContent();
        }

        [HttpPost("{code}/update")]
        public IActionResult Post(Guid code)
        {
            return NoContent();
        }

    }

}