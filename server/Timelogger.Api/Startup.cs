using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Timelogger.Entities;
using Timelogger.Models.Interfaces;
using Timelogger.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System.Buffers;

namespace Timelogger.Api
{
    public class Startup
	{
		private readonly IHostingEnvironment _environment;
		public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env)
		{
			_environment = env;

			var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
        {
			// Add framework services.
			services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());

			if (_environment.IsDevelopment())
			{
				services.AddCors();
			}
			
			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<ITimeLogRepository, TimeLogRepository>();

			services.AddMvc(options => 
			{
				options.OutputFormatters.Clear();
            	options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
            	{
                	ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            	}, ArrayPool<char>.Shared));
			});
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseCors(builder => builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials());
			}

			app.UseMvc();

			// Seed "database" with example data
			var context = app.ApplicationServices.GetService<ApiContext>();
			AddExampleData(context);
		}

		private static void AddExampleData(ApiContext context)
		{
			var testProject1 = new Project
			{
				Id = 1,
				Name = "e-conomic Interview"
			};
			var testProject2 = new Project
			{
				Id = 2,
				Name = "Secret project"
			};

			context.Projects.Add(testProject1);
			context.Projects.Add(testProject2);

			var testTimeLog1 = new TimeLog {
				TimeSpent = 2.5,
				Date = DateTime.Now,
				ProjectId = testProject1.Id
			};
			var testTimeLog2 = new TimeLog {
				TimeSpent = 5.23,
				Date = DateTime.Now,
				ProjectId = testProject1.Id
			};

			context.TimeLogs.Add(testTimeLog1);
			context.TimeLogs.Add(testTimeLog2);

			context.SaveChanges();
		}
	}
}
