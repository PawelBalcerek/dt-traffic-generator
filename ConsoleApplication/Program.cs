using System;
using Serilog;
using Serilog.Events;
using TestLibrary.Infrastructure.RunTest.Concrete;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .WriteTo.Console()
                .WriteTo.File("logs\\dt-traffic-generator-console-app-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Starting up");
                //TODO tutaj powinien byc jedynie kod rozruchowy (ewentualnie pobieranie parametrów z konsoli)
                //TODO w tym projekcie "ConsoleApplication" nie powinno być żadnej logiki działąnia testów, 
                // natomiast powinna być wywoływana logika testów za pomocą metody "RunTest"
                // przykład uruchomienia poniżej
                TestRunner testRunner = new TestRunner();
                testRunner.RunTest(1);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
