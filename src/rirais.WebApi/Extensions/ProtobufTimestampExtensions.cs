namespace rirais.WebApi.Extensions;

internal static class ProtobufTimestampExtensions
{
    public static DateOnly ToDateOnly(this Google.Protobuf.WellKnownTypes.Timestamp timestamp)
    {
        var dateTime = timestamp.ToDateTime();
        return DateOnly.FromDateTime(dateTime);
    }
}