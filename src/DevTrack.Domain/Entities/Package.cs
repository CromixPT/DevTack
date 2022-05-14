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


    public override string ToString()
    {
        return $"Package:{{ \"Code\": {Code} \"Title\": {Title}}}";
    }

    public void StatusUpdate(PackageStatus status)
    {
        Delivered = status == PackageStatus.Delivered;

        var update = new PackageUpdate(status, Id);
        Updates.Add(update);
    }

    public void Deconstruct(out Guid code, out string title, out decimal weight,
        out bool delivered,
        out DateTime postedAt,
        out PackageStatus currentStatus)
    {
        code = Code;
        title = Title;
        weight = Weight;
        delivered = Delivered;
        postedAt = PostedAt;
        currentStatus = Updates.LastOrDefault(p => p.Id == Id)!.Status;
    }

}