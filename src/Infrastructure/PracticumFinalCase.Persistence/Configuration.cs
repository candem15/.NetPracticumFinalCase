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
                return configurationManager["ConnectionStrings:SqlServerConnectionTest"];
            }
        }

        static public string ConnectionStringSqlServerTest
        {
            get
            {
                return "Server = DESKTOP-59ACA5K; Database = FinalCaseDbTest; User Id = eray; Password = Eray#Admin1.;Trust Server Certificate=true; Pooling=true;";
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
