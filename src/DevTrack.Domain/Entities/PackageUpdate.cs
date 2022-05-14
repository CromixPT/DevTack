namespace DevTrack.Domain.Entities;

public class PackageUpdate
{

    public PackageUpdate(PackageStatus status, long packageId)
    {
        Status = status;
        UpdatedAt = DateTime.UtcNow;
        PackageId = packageId;
    }

    public long Id { get; private set; }
    public long PackageId { get; private set; }
    public PackageStatus Status { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}
