using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTrack.Application.Common.Interfaces;
using DevTrack.Domain.Entities;
using DevTrack.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Infrastructure.Repositories
{
    public class PackageRepository : IPackageRepository
    {

        private readonly DevTrackContext _context;

        public PackageRepository(DevTrackContext context)
        {
            _context = context;
        }

        public async Task AddNewPackageAsync(Package package)
        {
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Package>> GetAllPackagesAsync()
        {

            var packages = await _context.Packages.ToListAsync();
            return packages;
        }

        public async Task<Package> GetPackageByCodeAsync(Guid code)
        {
            var package = await _context.Packages.FirstOrDefaultAsync(p => p.Code.Equals(code));

            if (package == default)
            {
                return null;
            }

            return package;
        }

        public async Task<Package> UpdatePackageStatus(Guid code, PackageStatus status)
        {
            var package = await _context.Packages.FirstOrDefaultAsync(p => p.Code.Equals(code));

            package.StatusUpdate(status);
            await _context.SaveChangesAsync();

            return package;
        }
    }
}