using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();
            var services = Startup.ConfigureServices(config);
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<Startup>().Run(); //Kod uruchomieniowy programu powinien sie znajdowac w klasie Startup -> Run
        }
    }
}
