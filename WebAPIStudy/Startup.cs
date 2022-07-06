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

            services.AddTransient<ServiceTransient>();
            services.AddScoped<ServiceScoped>();
            services.AddSingleton<ServiceSingleton>();
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
