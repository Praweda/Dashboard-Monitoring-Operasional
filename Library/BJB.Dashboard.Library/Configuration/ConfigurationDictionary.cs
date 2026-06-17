using System.Collections.Concurrent;

namespace BJB.Dashboard.Library.Configuration;

public class ConfigurationDictionary
{
    private static readonly ConcurrentDictionary<string, string> configMap = new ConcurrentDictionary<string, string>();

    public static void ReadConfig(string key, string value)
    {
        configMap.AddOrUpdate(key, value, (x, y) => y);
    }

    public static string? GetConfig(string code)
    {
        configMap.TryGetValue(code, out string? value);
        return value;
    }
}
