using CoreFoundamentals.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreFoundamentals
{
    public class Startup

    {

        public Startup(IHostingEnvironment env)
        {
            var builde = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration=builde.Build();

        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton(Configuration);
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ////app.UseWelcomePage("/welcome1");
            //app.UseWelcomePage(new WelcomePageOptions()
            //{
            //    Path = "/welcome"
            //});

            app.UseFileServer();

            //app.Run(async (context) =>
            //{
            //    //var message = Configuration["Greeting"];
            //    //throw new Exception("Invalid response! exception");
            //    var message = greeter.GetGreetintg();
            //    await context.Response.WriteAsync(message);
            //});

            app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);
            app.Run(ctx => ctx.Response.WriteAsync("Not found!"));
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
