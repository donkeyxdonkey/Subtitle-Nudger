using System.Diagnostics.CodeAnalysis;

namespace SubtitleNudger;

public static class StringExtensions
{
    public static bool IsNullEmptyOrNewLine(this string? value)
    {
        if (value == null || value.Length == 0) return true;

        return value.Trim().Replace("\r\n", string.Empty).Replace(" ", "").Length == 0;
    }
}
