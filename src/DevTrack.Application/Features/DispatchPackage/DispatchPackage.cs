using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTrack.Application.Features.DispatchPackage.Models;
using MediatR;

namespace DevTrack.Application.Features.DispatchPackage
{
    public class DispatchPackage
    {

        public record Request(PackageModel Package) : IRequest<Response>;

        public record Response(PackageModel Package);

        public class Handler : IRequestHandler<Request, Response>
        {
            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}