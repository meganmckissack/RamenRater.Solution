using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc; //new using statement takes care of apiversion error
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer;
// using Microsoft.AspNetCore.Mvc.ApiExplorer;
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
              // options.ApiVersionReader = ApiVersionReader.Combine(
              //   new QueryStringApiVersionReader("api-version"),
              //   new HeaderApiVersionReader("api-version")); 
            });

            services.AddVersionedApiExplorer(options => 
            {
              // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

            // services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            // services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());

            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();

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

            app.UseSwagger();
            app.UseSwaggerUI(
            options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    // public class SwaggerDefaultValues : IOperationFilter
    // {
    //   public void Apply(OpenApiOperation operation, OperationFilterContext context)
    //   {
    //     var apiDescription = context.ApiDescription;
    //     operation.Deprecated |= apiDescription.IsDeprecated();

    //     if (operation.Parameters == null)
    //         return;

    //     // REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/412
    //     // REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/pull/413
    //     foreach (var parameter in operation.Parameters)
    //     {
    //         var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
    //         if (parameter.Description == null)
    //         {
    //             parameter.Description = description.ModelMetadata?.Description;
    //         }

    //         if (parameter.Schema.Default == null && description.DefaultValue != null)
    //         {
    //             parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());
    //         }

    //         parameter.Required |= description.IsRequired;
    //     }
    // }

    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
      private readonly IApiVersionDescriptionProvider _provider;

      public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

      public void Configure(SwaggerGenOptions options)
      {
        // add a swagger document for each discovered API version
        // note: you might choose to skip or document deprecated API versions differently
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
      }

      public void Configure(string name, SwaggerGenOptions options) 
      {
        Configure(options);
      }

    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = "Ramen API",
            Version = description.ApiVersion.ToString(),
        };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }

        return info;
      }
    }
  }

