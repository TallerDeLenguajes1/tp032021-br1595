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
using tp032021_br1595.Models.Repostorios;
using AutoMapper;
using NLog;
using NLog.Web;
using tp032021_br1595.Models.SQLite;

namespace tp032021_br1595
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
            services.AddHealthChecks();
            services.AddAutoMapper(typeof(SistemaDeCadeterias.PerfilDeMapeo));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddAuthorization();

            RepositorioCadete RepoCadetes = 
                new RepositorioCadete(
                    Configuration.GetConnectionString("Default"), 
                    NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger());

            RepositorioCadeteria RepoCadeterias = 
                new RepositorioCadeteria(
                    Configuration.GetConnectionString("Default"),
                    NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger());

            RepositorioPedido RepoPedidos = 
                new RepositorioPedido(
                    Configuration.GetConnectionString("Default"),
                    NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger());

            RepositorioUsuario RepoUsuarios = 
                new RepositorioUsuario(
                    Configuration.GetConnectionString("Default"),
                    NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger());

            RepositorioCliente RepoClientes = 
                new RepositorioCliente(
                    Configuration.GetConnectionString("Default"),
                    NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger());

            DataContext data = new DataContext(RepoCadetes, RepoPedidos, RepoUsuarios, RepoClientes, RepoCadeterias);
            services.AddSingleton(data);

            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
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
            app.UseSession();
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
