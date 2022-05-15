using DevTrack.Domain.Entities;

namespace DevTrack.Application.Common.Interfaces;

public interface IPackageRepository
{
    public Task<List<Package>> GetAllPackagesAsync();
    public Task<Package> GetPackageByCodeAsync(Guid code);
    public Task AddNewPackageAsync(Package package);
    public Task<Package> UpdatePackageStatus(Guid code, PackageStatus status);

}