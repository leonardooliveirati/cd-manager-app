using CDManager.Application.Services;
using CDManager.Domain.Interfaces;
using CDManager.Infrastructure.Persistence;
using CDManager.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CDManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurando o acesso ao banco de dados
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Registrando interfaces e implementações para injeção de dependência
            services.AddScoped<ICDService, CDService>();
            services.AddScoped<ICDRepository, CDRepository>();

            // Configurando a injeção de dependência para os controladores da API
            services.AddControllers();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
