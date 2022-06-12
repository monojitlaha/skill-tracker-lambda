
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SkillTrackerLambda.Services;
using SkillTrackerLambda.Repository;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;

namespace SkillTrackerLambda
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
            //services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSingleton(Configuration);

            services.AddCors(options => options.AddPolicy("SkillTracker", builder =>
            {
                builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            }));

            services.AddSingleton<IDynamoDBContext, DynamoDBContext>(p => 
                                new DynamoDBContext(new AmazonDynamoDBClient()));
            services.AddSingleton<IDynamoDBClient, DynamoDBClient>();
            services.AddSingleton<IProfileService, ProfileService>();

            services.AddHttpContextAccessor();
            services.AddMvcCore(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("SkillTracker");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
