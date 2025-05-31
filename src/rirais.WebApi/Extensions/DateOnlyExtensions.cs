namespace rirais.WebApi.Extensions;

internal static class DateOnlyExtensions
{
    public static Google.Protobuf.WellKnownTypes.Timestamp ToTimestamp(this DateOnly value)
    {
        var dateTime = value.ToDateTime(TimeOnly.MinValue);
        return Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(dateTime.ToUniversalTime());
    }
}