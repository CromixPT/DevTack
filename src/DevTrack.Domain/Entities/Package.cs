namespace DevTrack.Domain.Entities;

public class Package
{
    public Package(string title, decimal weight)
    {
        Code = Guid.NewGuid();
        Title = title;
        Weight = weight;
        Delivered = false;
        PostedAt = DateTime.UtcNow;
        Updates = new();
    }

    public long Id { get; private set; }
    public Guid Code { get; private set; }
    public string Title { get; private set; }
    public decimal Weight { get; private set; }
    public bool Delivered { get; private set; }
    public DateTime PostedAt { get; private set; }
    public List<PackageUpdate> Updates { get; private set; }

}