using Microsoft.Extensions.Configuration;

namespace PracticumFinalCase.Persistence
{
    static class Configuration
    {
        static public string ConnectionStringSqlServer
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PracticumFinalCase.WebApi/"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("SqlServerConnection");
            }
        }

        static public string ConnectionStringSqlServerTest
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PracticumFinalCase.WebApi/"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("SqlServerConnectionTest");
            }
        }

        static public string RedisDbHost
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PracticumFinalCase.WebApi/"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager["Redis:Host"];
            }
        }

    }
}
