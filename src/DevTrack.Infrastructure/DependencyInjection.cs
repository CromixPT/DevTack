using DevTrack.Application.Common.Interfaces;
using DevTrack.Infrastructure.Persistance;
using DevTrack.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevTrack.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DevTrackContext>();


        services.AddScoped<IPackageRepository, PackageRepository>();

        return services;
    }
}