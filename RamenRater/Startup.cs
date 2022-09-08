using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc; //new using statement takes care of apiversion error
using RamenRater.Models;

namespace RamenRater
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

            services.AddDbContext<RamenRaterContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
            services.AddControllers();

            //API versioning service
            services.AddApiVersioning(options => 
            {
              options.ReportApiVersions = true; //ReportApiVersions flag is used to add the API versions in the response header
              options.AssumeDefaultVersionWhenUnspecified = true;  //flag is used to set the default version when the client has not specified any versions. Without this flag, UnsupportedApiVersion exception would occur in the case when the version is not specified by the client
              options.DefaultApiVersion = new ApiVersion(1, 0);  //flag is used to set the default version count
              // options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0); //this line worked last time
              
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
