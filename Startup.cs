using System;
using System.Data;
using System.Linq;
using NorseGodApi.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace NorseGodApi
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

      services.AddMvc();
      // TODO register all Transient informations
      services.AddTransient<IDbConnection>(x => CreateDBContext());
      services.AddTransient<GodsRepository>();



    }

    private IDbConnection CreateDBContext()
    {
      var _connectionString = Configuration.GetSection("DB").GetValue<string>("gearhost");
      var connection = new MySqlConnection(_connectionString);
      connection.Open();
      return connection;
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseCors("CorsDevPolicy");
      }
      else
      {
        app.UseHsts();
      }
      //NOTE I dont remember what UseHttpsRedirection is but it was in the reference so better safe than sorry (shrug)
      // app.UseHttpsRedirection();

      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseMvc();
    }
  }
}

