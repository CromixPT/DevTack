using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTrack.Domain.Entities;

namespace DevTrack.Application.Common.Interfaces
{
    public interface IPackageRepository
    {
        public Task<List<Package>> GetAllPackagesAsync();
        public Package GetPackageByCode(Guid code);
        public Task AddNewPackageAsync(Package package);

    }
}