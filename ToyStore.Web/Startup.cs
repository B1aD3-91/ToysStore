using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ToysStore.Domain.Repository;
using ToysStore.Web;

namespace ToyStore.Web
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
            services.AddDatabaseDeveloperPageExceptionFilter();
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvcCore();
            services.AddWebOptimizer(pipeline =>
            {
                pipeline.AddCssBundle("/css/bundle.min.css",
                    "/wwwroot/css/bootstrap.css",
                    "/wwwroot/css/font-awesome.css",
                    "/wwwroot/css/site.css"
                    )
                .UseContentRoot();
                pipeline.AddJavaScriptBundle("/js/bundle.min.js",
                    "/wwwroot/js/jquery-3.5.1.js",
                    "/wwwroot/js/bootstrap.bundle.js",
                    "/wwwroot/js/jquery.unobtrusive-ajax.js",
                    "/wwwroot/js/jquery.validate.js")
                .UseContentRoot();
            });


            services.AddDbContext<ContextRepository>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDomainServiceExtension();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseWebOptimizer();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Main}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
      
    }
}
