using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MiTiendita.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text.Json.Serialization;
using MiTiendita.Helpers;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace MiTiendita
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
            
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection"))));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("SqLiteDefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            // Servicios Singleton (Uno para toda la aplicación)
            // Servicios Scoped (Uno para cada sesión UYno diferete cada vez que la sesión cambia)
            // Servicios Transient (Transitorios: Uno diferente cada vez que lo solicito)
            services.AddTransient<MiPrimerServicio>();
            // // Register the Swagger generator, defining 1 or more Swagger documents
            // // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mi Tiendita API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Daniel Lozano",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/dlozanonavas"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under Mi Licencia",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                        options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    })
                    .AddJsonOptions(c =>
                    {
                        c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                        c.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                        c.JsonSerializerOptions.PropertyNamingPolicy = null;
                    });
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


            // // Enable middleware to serve generated Swagger as a JSON endpoint.
            // app.UseSwagger();

            // // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "/api/docs";
            });


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
