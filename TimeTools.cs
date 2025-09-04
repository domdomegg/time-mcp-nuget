using ModelContextProtocol.Server;
using System.ComponentModel;

[McpServerToolType]
public static class TimeTools
{
    [McpServerTool]
    [Description("Gets the current UTC date and time in RFC 3339 format")]
    public static string GetCurrentUtcTime()
    {
        return DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }
}