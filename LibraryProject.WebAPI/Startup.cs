using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryProject.DAL.Abstract;
using LibraryProject.DAL.Concrete;
using LibraryProject.DAL.Repository;
using LibraryProject.DAL.Repository.Dapper;
using LibraryProject.Manager.Abstract;
using LibraryProject.Manager.Concrete;
using LibraryProject.WebAPI.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace LibraryProject.WebAPI
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
         var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, false).Build();
         services.AddScoped<IStudentManager, StudentManager>();
         services.AddScoped<IStudentDAL, StudentDAL>();
         services.AddScoped<IBookManager, BookManager>();
         services.AddScoped<IBookDAL, BookDAL>();
         services.AddScoped<IStudentsBookManager, StudentsBookManager>();
         services.AddScoped<IStudentsBookDAL, StudentsBookDAL>();
         services.AddScoped<IUserDAL, UserDAL>();
         services.AddScoped<IUserManager, UserManager>();

         Constants.LibraryConnection = Configuration.GetSection("ConnectionStrings:LibraryConnection").Get<string>();

         services.AddMvc();
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("CoreSwagger", new Info
            {
               Title = "Swagger on ASP.NET Core",
               Version = "4.0.1",
               Description = "Try Swagger on (ASP.NET Core 2.2)"
            });
            //c.AddSecurityDefinition("Bearer", new ApiKeyScheme
            //{
            //   Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            //   Name = "Authorization",
            //   In = "header",
            //   Type = "apiKey"
            //});
         });
         services.AddAutoMapper();
         var appSettingsSection = Configuration.GetSection("AppSettings");
         services.Configure<AppSettings>(appSettingsSection);
         services.Configure<PasswordKeys>(Configuration.GetSection("PasswordKeys"));

      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseMvc();
         app.UseSwagger();
         app.UseSwaggerUI(c =>
         {
            c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "Swagger on ASP.NET Core");
         });
         app.UseHttpsRedirection();
      }
   }
}
