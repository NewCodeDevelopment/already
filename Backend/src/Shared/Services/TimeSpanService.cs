using System.Text;

namespace Shared.Services;

public static class TimeSpanService
{
    public static string ToLongTimeString(TimeSpan timeSpan)
    {
        var stringBuilder = new StringBuilder();
        if (timeSpan.Days != 0) stringBuilder.Append(timeSpan.Days + " Dagen");

        if (timeSpan.Days != 0 && timeSpan.Hours != 0) stringBuilder.Append(", ");

        if (timeSpan.Hours != 0) stringBuilder.Append(timeSpan.Hours + " Uren");

        if (timeSpan.Days != 0 && timeSpan.Minutes != 0 || timeSpan.Hours != 0 && timeSpan.Minutes != 0) stringBuilder.Append(", ");

        if (timeSpan.Minutes != 0) stringBuilder.Append(timeSpan.Minutes + " Minuten");
        return stringBuilder.ToString();
    }
}
