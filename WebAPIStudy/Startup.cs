using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebAPIStudy.Data;
using WebAPIStudy.Services;

namespace WebAPIStudy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureService(IServiceCollection services) //Injection services method
        {
            services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //ignore cicles into the set
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));

            services.AddSingleton<IService>();

            services.AddTransient<ServiceTransient>(); //one instance for each situation
            services.AddScoped<ServiceScoped>(); //one instance for each Http peticion 
            services.AddSingleton<ServiceSingleton>(); //one instance for everything 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }   
}
