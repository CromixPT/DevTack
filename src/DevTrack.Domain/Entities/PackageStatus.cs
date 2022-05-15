using System.Text.Json.Serialization;

namespace DevTrack.Domain.Entities;


public enum PackageStatus
{
    Dispacthed,
    ReceivedAtDispatcher,
    InTransit,
    InDeveliry,
    Delivered
}