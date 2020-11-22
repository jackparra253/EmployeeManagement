using Application;
using Data;
using IApplication;
using IData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string political = "allow Localhost";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Application
            services.AddScoped<IEmployeeHourlySalary, EmployeeHourlySalary>();         
            services.AddScoped<IEmployeeMonthlySalary, EmployeeMonthlySalary>();
            services.AddScoped<IEmployeeQueryHandler, EmployeeQueryHandler>();
            services.AddScoped<IEmployeeExternalQueryHandler, EmployeeExternalQueryHandler>();

            //Data
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRoleServiceFake, RoleServiceFake>();
            services.AddScoped<IEmployeeExternalService, EmployeeExternalService>();

            services.AddDbContext<EmployeeContext>(option => option.UseSqlite
            (Configuration.GetConnectionString("EmployeeContext"), b => b.MigrationsAssembly("API")));

            services.AddDbContext<EmployeeContext>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: political,
                    builder =>
                    {
                        builder.WithOrigins("http://masglobaltestapi.azurewebsites.net")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();

            app.UseStaticFiles();

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
