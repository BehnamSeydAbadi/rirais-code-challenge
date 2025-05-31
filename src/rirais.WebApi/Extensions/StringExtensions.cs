namespace rirais.WebApi.Extensions;

internal static class StringExtensions
{
    public static Guid ToGuid(this string value) => Guid.Parse(value);

    public static DateOnly ToDateOnly(this string value)
    {
        var dateParts = value.Split('-').Select(p => int.Parse(p)).ToArray();
        return new DateOnly(dateParts[0], dateParts[1], dateParts[2]);
    }
}