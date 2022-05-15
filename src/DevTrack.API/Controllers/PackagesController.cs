using System.Net;
using DevTrack.Application.Features.Packages.DispatchPackage;
using DevTrack.Application.Features.Packages.GetAllPackages;
using DevTrack.Application.Features.Packages.GetPackageByCode;
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
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(List<Package>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllPackagesAsync()
    {
        var request = new GetPackages.Request();
        var packages = await _mediator.Send(request);
        return Ok(packages);
    }


    [HttpGet("{code}", Name = "GetByCode")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Package), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPackageByCode(Guid code)
    {
        var request = new GetPackageByCode.Request(code);
        var package = await _mediator.Send(request);

        if (package == null)
        {
            return NotFound();
        }
        return Ok(package);

    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Package), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> PostAsync(DispatchPackage.Request request)
    {
        var response = await _mediator.Send(request);
        return CreatedAtRoute("GetByCode", new { code = response.Package.Code }, response.Package);
    }

    [HttpPost("{code}/update")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Package), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Post(Guid code, UpdatePackageStatus.Request updateRequest)
    {

        if (code != updateRequest.Package.PackageCode)
        {
            return BadRequest();
        }

        await _mediator.Send(updateRequest);

        return NoContent();
    }

}