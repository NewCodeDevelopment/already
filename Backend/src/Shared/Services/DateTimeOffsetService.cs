namespace Shared.Services;

public static class DateTimeOffsetService
{
    public static string ToLongDateTimeString(DateTimeOffset dateTimeOffset)
    {
        var convertedDateTimeOffset = dateTimeOffset.AddHours(1);
        return
          $"{convertedDateTimeOffset.DateTime.ToLongDateString()}, {convertedDateTimeOffset.DateTime.ToShortTimeString()}";
    }
}
