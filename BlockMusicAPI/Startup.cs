using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Old DLL - Emergency Only !
//using BlockMusicAPI.Models;
using BlockMusicAPI.FreshDbC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlockMusicAPI
{
    public class Startup
    {
        static string serverURL = "http://lorikmanaj-001-site1.itempurl.com";
        static string localIIS = "http://192.168.217.1:8085/api";
        static string localURL = "http://localhost:44374/";
        static string currentURL = serverURL;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins();
                    });
            });

            services.AddCors(options =>
                options.AddPolicy("AllowCors",
                    builder =>
                    {
                        builder
                        .WithOrigins()
                        .AllowAnyOrigin()
                        .WithMethods("GET", "PUT", "POST", "DELETE")
                        .AllowAnyHeader();
                    })
            );

            services.AddDbContext<BMContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("TestConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("AllowCors");
        }
    }
}
