using System;
using Microsoft.Extensions.Configuration;

namespace BJB.Dashboard.Library.Configuration;

public class ConfigurationBuilders
{
    public static void BuildConfiguration(IConfiguration configuration)
    {
        ConfigurationDictionary.ReadConfig("SqlServerDbContext", configuration.GetSection("ConnectionStrings:SqlServerDbContext").Value ?? throw new InvalidOperationException("SqlServerDbContext is not configured."));
        ConfigurationDictionary.ReadConfig("ApplicationDatabaseEngine", configuration.GetSection("ApplicationConfig:DBEngine").Value ?? throw new InvalidOperationException("DBEngine is not configured."));
    }
}
