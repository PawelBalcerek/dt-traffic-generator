using System;
using System.Collections.Generic;
using ConsoleApplication.Examples;
using Data.Models;
using Data.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using TestLibrary.Creators.Abstract;
using TestLibrary.Creators.Concrete;
using TestLibrary.Infrastructure.ObjectsConverter.Abstract;
using TestLibrary.Infrastructure.ObjectsConverter.Concrete;
using TestLibrary.Infrastructure.RunTest.Abstract;
using TestLibrary.Infrastructure.RunTest.Concrete;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.Providers.Abstract;
using TestLibrary.Providers.Concrete;
using TestLibrary.Repositories.Abstract;

namespace ConsoleApplication
{
    public class Startup
    {
        private readonly IExamplesRunner _examplesRunner;
        private readonly ITestRun _testRun;
        public Startup(IExamplesRunner examplesRunner, ITestRun testRun)
        {
            _examplesRunner = examplesRunner;
            _testRun = testRun;
        }

        public static IServiceCollection ConfigureServices(IConfiguration configuration)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IExamplesRunner, ExamplesRunner>();
            services.AddTransient<EfficiencyTestDbContext>();
            services.AddTransient<IEndpointRepository, EndpointRepository>();
            services.AddTransient<IEndpointsProvider, EndpointsProvider>();
            services.AddTransient<IEndpointsCreator, EndpointsCreator>();
            services.AddTransient<ITestParametersRepository, TestParametersRepository>();
            services.AddDbContext<EfficiencyTestDbContext>(options => options.UseNpgsql(configuration.GetSection("ConnectionStrings")["EfficiencyTestDatabase"]));
            services.AddTransient<ITestRunner, TestRunner>();
            services.AddTransient<ITestParametersProvider, TestParametersProvider>();
            services.AddTransient<IDataToBusinessObjectsConverter, DataToBusinessObjectsConverter>();
            services.AddTransient<ITestParametersCreator, TestParametersCreator>();
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<ITestsProvider, TestsProvider>();
            services.AddTransient<ITestsCreator, TestsCreator>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IReportProvider, ReportProvider>();
            services.AddTransient<ITestRun, TestRun>();

            services.AddTransient<Startup>();
            return services;
        }

        public void Run()
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
                //_testRun.TestMain();
                //_examplesRunner.GetTestsParameters();
                //_examplesRunner.AddTestParameters();
                //_examplesRunner.GetTestParameters();
                //_examplesRunner.GetTestsParameters();
                //_examplesRunner.AddEndpoint();
                //_examplesRunner.GetEndpoint();
                //_examplesRunner.GetEndpoints();
                //_examplesRunner.AddTests();
                //_examplesRunner.GetTest();
                //_examplesRunner.GetTests();
                _examplesRunner.RunTest(5);
                
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
