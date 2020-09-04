using Api.Portal.BusinessLayer.Busienss.Implemention;
using Api.Portal.BusinessLayer.Busienss.Interface;
using Api.Portal.DataLayer.Repository.Implemention;
using Api.Portal.DataLayer.Repository.Interface;
using Api.Portal.Logging;
using Api.Portal.MapperProfile;
using Api.Portal.Model;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 

namespace Api.Portal
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

            services.AddTransient<IBankPortalRepository, BankPortalRepository>();
            services.AddTransient<IBankPortal, BankPortal>();
            services.AddTransient<ILogHelper<CreditCardDto>, LogHelper<CreditCardDto>>();
            services.AddTransient<IValidator<CreditCardDto>, Validator.CreditCardValidator>();

            var mapperConfig = new MapperConfiguration(e =>
            {
                e.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
             
            //services.AddMvc().AddFluentValidation(f =>
            //{
            //    f.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
