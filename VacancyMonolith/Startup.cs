using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using VacancyMonolith.Models.Realisations;

namespace VacancyMonolith
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

            //для докера
            //"DefaultConnection": "Server=database,1434;Database=VacanciesAppDB;User ID=sa;Password=Thesecretpassword_1;Trusted_Connection=False"

            //для локалки
            //"DefaultConnection": "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VacanciesAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

            services.AddDbContext<VacancyContext>(options=> options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //без этого в docker'e не работает. Возможно, еще нужно настроить CORS
            //services.AddHttpsRedirection(options=>
            //options.HttpsPort = 25010);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VacancyMonolith", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VacancyMonolith v1"));

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
