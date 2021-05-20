using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Endava.Internship2020.WebApiExamples.DataAccess;
using Microsoft.EntityFrameworkCore;
using Endava.Internship2020.WebApiExamples.Services;
using Endava.Internship2020.WebApiExamples.Services.Interfaces;

namespace TicketsAPI
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
            services.AddControllers();

            services.AddScoped<TicketsService>();
            services.AddScoped<ITicketsService, TicketsService>();

            services.AddScoped<TicketsRepository>();
            services.AddScoped<ITicketsRepository, TicketsRepository>();

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo
               {
                   Version = "v1",
                   Title = "School OF .NET",
                   Description = "A simple example ASP.NET Core Web API",
                   TermsOfService = new Uri("https://example.com/terms"),
                   Contact = new OpenApiContact
                   {
                       Name = "Miroslav Stoynov",
                       Email = string.Empty,
                       Url = new Uri("https://twitter.com/spboyer"),
                   }
               });
           });

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=TicketAppDb;Integrated Security=True;");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "SCHOOL OF .NET SERVICE API V1");    

                   c.RoutePrefix = string.Empty;
               });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Migrate(app);
        }

        private static void Migrate(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dataContext = scope.ServiceProvider.GetService<DataContext>();
            dataContext.Database.Migrate();
        }
    }
}
