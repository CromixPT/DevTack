using System.Net;
using DevTrack.Application.Features.Packages.DispatchPackage;
using DevTrack.Application.Features.Packages.GetAllPackages;
using DevTrack.Application.Features.Packages.UpdatePackageStatus;
using DevTrack.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevTrack.API.Controllers;

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
    public async Task<IActionResult> GetAllPackagesAsync()
    {
        var request = new GetPackages.Request();
        var packages = await _mediator.Send(request);
        return Ok(packages);
    }


    [HttpGet("{code}", Name = "GetByCode")]
    public IActionResult GetPackageByCode(Guid code)
    {
        return Ok(new Package("Package 1", 1.3M));
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    // [ProducesResponseType(typeof(DispatchPackage.Response), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> PostAsync(DispatchPackage.Request request)
    {
        _logger.LogInformation("Incoming!");
        var response = await _mediator.Send(request);

        return CreatedAtRoute("GetByCode", new { code = response.Package.Code }, response.Package);
    }

    [HttpPost("{code}/update")]
    public IActionResult Post(Guid code, UpdatePackageStatus.UpdateRequest request)
    {
        var package = new Package("Package 1", 2.5M);
        package.StatusUpdate(PackageStatus.InTransit);
        return NoContent();
    }

}