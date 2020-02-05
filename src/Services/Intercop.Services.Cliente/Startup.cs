using Autofac;
using Autofac.Extensions.DependencyInjection;
using Intercop.Common.Utils.Swagger;
using Intercop.Services.Cliente.Domain.Business;
using Intercop.Services.Cliente.Domain.Repositories;
using Intercop.Services.Cliente.Infrastructure.Entity;
using Intercop.Services.Cliente.Infrastructure.Entity.Repositories;
using Intercop.Services.Cliente.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Intercop.Services.Cliente
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerDocs();

            //Cliente
            services.AddTransient<IClientesRepository, ClientesRepository>();
            services.AddTransient<IClienteBusiness, ClienteBusiness>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<Context>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwaggerDocs();
            app.UseMvc();
        }
    }
}
