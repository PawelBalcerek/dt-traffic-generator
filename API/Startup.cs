using System;
using System.IO;
using System.Reflection;
using Data.Models;
using Data.Repositories.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestLibrary.Infrastructure.RunTest.Abstract;
using TestLibrary.Infrastructure.RunTest.Concrete;
using Swashbuckle.AspNetCore.Swagger;
using TestLibrary.Creators.Abstract;
using TestLibrary.Creators.Concrete;
using TestLibrary.Infrastructure.ObjectsConverter.Abstract;
using TestLibrary.Infrastructure.ObjectsConverter.Concrete;
using TestLibrary.Repositories.Abstract;
using TestLibrary.Providers.Abstract;
using TestLibrary.Providers.Concrete;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<EfficiencyTestDbContext>();
            services.AddTransient<IEndpointRepository, EndpointRepository>();
            services.AddTransient<IEndpointsProvider, EndpointsProvider>();
            services.AddTransient<IEndpointsCreator, EndpointsCreator>();
            services.AddTransient<ITestParametersRepository, TestParametersRepository>();
            services.AddDbContext<EfficiencyTestDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("EfficiencyTestDatabase")));
            services.AddTransient<ITestRunner, TestRunner>();
            services.AddTransient<ITestParametersProvider, TestParametersProvider>();
            services.AddTransient<IDataToBusinessObjectsConverter, DataToBusinessObjectsConverter>();
            services.AddTransient<ITestParametersCreator, TestParametersCreator>();
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<ITestsProvider, TestsProvider>();
            services.AddTransient<ITestsCreator, TestsCreator>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IReportProvider, ReportProvider>();
          
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "dt-traffic-generator Api", Description = "DayTrader - Traffic Generation - Swagger Api Documentation" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger(c=> {
                c.RouteTemplate = "/dt-traffic-generator/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/dt-traffic-generator/swagger/v1/swagger.json", "dt-traffic-generator Api");
                c.RoutePrefix = "dt-traffic-generator/swagger";
            });

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetService<EfficiencyTestDbContext>())
                {
                    if (dbContext.Database.GetPendingMigrations().Any())
                    {
                        dbContext.Database.Migrate();
                    }
                }
            }
        }
    }
}
