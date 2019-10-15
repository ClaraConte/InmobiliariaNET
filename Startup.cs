using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inmobiliaria
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {   //Autenticacion es decir quien soy y autorizacion es si tengo ono permisos para ingresar en lqas distintas secciones
            //Autorización requiere primero de la autenticación
            //Para autenticación
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Home/Login";
                options.LogoutPath = "/Home/Logout";
                options.AccessDeniedPath = "/Home/Restringido";
            });

            //Autorizacion
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrador", policy => policy.RequireClaim(ClaimTypes.Role, "administrador"));
                options.AddPolicy("Propietario", policy => policy.RequireClaim(ClaimTypes.Role, "propietario"));
            });

            services.AddMvc();
            services.AddTransient<IRepositorio<Usuario>, RepositorioUsuario>();
            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();

            services.AddTransient<IRepositorio<UsuarioTipo>, RepositorioUsuarioTipo>();

            services.AddTransient<IRepositorio<Inmueble>, RepositorioInmueble>();
            services.AddTransient<IRepositorioInmueble, RepositorioInmueble>();

            services.AddTransient<IRepositorio<InmuebleTipo>, RepositorioInmuebleTipo>();
            services.AddTransient<IRepositorio<InmuebleUso>, RepositorioInmuebleUso>();

            services.AddTransient<IRepositorio<Contrato>, RepositorioContrato>();
            services.AddTransient<IRepositorioContrato, RepositorioContrato>();

            services.AddTransient<IRepositorio<ContratoGarantia>, RepositorioContratoGarantia>();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Para autenticación
            app.UseStaticFiles();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.None,
            });
            app.UseAuthentication();

            // Muestra errores para el desarrollador
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Ejecuta el contexto 
            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/

            // Rutea seccion y accion por defecto
            app.UseMvc(routes =>
            {
                //Para loguearse
                routes.MapRoute(
                  name: "login",
                  template: "login/{**accion}",
                  defaults: new {controller = "Home", action = "Login"});

                routes.MapRoute(
                  name: "default",
                  template: "{controller=Usuarios}/{action=Index}/{id?}");
            });
        }
    }
}
