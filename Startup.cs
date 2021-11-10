using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;
using tp032021_br1595.Models;
//using NLog;

namespace tp032021_br1595
{
    public class Startup
    {
        //static List<Cadete> ListadoCadetes = new List<Cadete>();
        static DBTemporal DB = new DBTemporal();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();

            services.AddAuthorization();
            RepositorioCadete RepoCadetes = new RepositorioCadete(Configuration.GetConnectionString("Default"));
            services.AddSingleton(RepoCadetes);
            RepositorioCadeteria RepoCadeterias = new RepositorioCadeteria(Configuration.GetConnectionString("Default"));
            services.AddSingleton(RepoCadeterias);
            var connectionString = Configuration.GetConnectionString("Default");
            services.AddControllersWithViews();//addRazorRuntimeCompilation();
            services.AddSingleton(DB);//importante en esta altura del cursado
            services.AddDistributedMemoryCache();
            services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
            });
            services.AddMvc();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
