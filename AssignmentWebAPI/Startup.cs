using AssignmentWeb.Domain.Interfaces;
using AssignmentWeb.Domain.Services;
using AssignmentWeb.Repository.Context;
using AssignmentWeb.Repository.Models;
using AssignmentWeb.Repository.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace AssignmentWeb.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMvc().AddJsonOptions(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
            
            services.AddDbContext<RubiconContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Rubicon")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Rubicon API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // IOC
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddTransient<DatabaseDeployer>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DatabaseDeployer dd)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rubicon API");
                });

               Mapper.Initialize(cfg => 
                   cfg.CreateMap<Post,BlogPostViewModel>());

                dd.Migrate();
                app.UseMvc();

            }

        }

    }
}
