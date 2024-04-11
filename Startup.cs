using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApiCRUD.Data;
using WebApiCRUD.Data.Interfaces;

namespace WebApiCRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration {get;}

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x=> {
                        //x.UseLazyLoadindgProxies(); //revisar por que da error
                        x.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));                        
            });
            services.AddControllers();
            services.AddScoped<IApiRepository, ApiRepository>(); //Agregar para poder usuar el repositorio en los controladores
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiCRUD", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}