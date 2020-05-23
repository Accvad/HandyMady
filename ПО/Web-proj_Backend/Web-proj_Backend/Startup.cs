using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web_proj_Backend.Data;
using Web_proj_Backend.Data.Interfaces;
using Web_proj_Backend.Data.Repositories;
using Web_proj_Backend.Domain;
using Web_proj_Backend.Middleware;

namespace Web_proj_Backend
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
            services.AddScoped<PersonContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IPositionsRepository, PositionsRepository>();
            services.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
            services.AddScoped<IStoresRepository, StoresRepository>();
            services.AddScoped<IGoodsRepository, GoodsRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();


            services.AddDbContext<DataContext>(
                options => options.UseNpgsql("Server=localhost;" +
                                             "UserId=Accvad;" +
                                             "Password=wololo;" +
                                             "Port=5432;" +
                                             "Database=HandyMadyProj",
                npgSqlOptions =>
                {
                    npgSqlOptions.MigrationsAssembly(typeof(DataContext).Assembly.GetName()
                        .Name);
                }));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000", "http://localhost:5000")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ApiKey>();
            app.UseCors("MyPolicy");
            //app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
