using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.DAL.Abstract;
using LibraryProject.DAL.Concrete;
using LibraryProject.DAL.Repository;
using LibraryProject.DAL.Repository.Dapper;
using LibraryProject.Manager.Abstract;
using LibraryProject.Manager.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

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


         Constants.LibraryConnection = Configuration.GetSection("ConnectionStrings:LibraryConnection").Get<string>();

         services.AddMvc();
         services.AddMvc().AddJsonOptions(opt =>
         {
            if (opt.SerializerSettings.ContractResolver != null)
            {
               var resolver = opt.SerializerSettings.ContractResolver as DefaultContractResolver;
               resolver.NamingStrategy = null;
            }
         });


      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseMvc();
      }
   }
}
