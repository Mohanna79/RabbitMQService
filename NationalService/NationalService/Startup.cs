
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NationalCopyService.Contracts;
using NationalCopyService.Helpers;
using NationalCopyService.Services;

namespace NationalCopyService
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
            //services.AddTransient<IReceiveTripsRepository, ReceiveTripsRepository>();
            //services.AddTransient<INumberTripsRepository, NumberTripsRepository>();
            //services.AddTransient<IWeatherRepository, WeatherRepository>();
            //services.RegisterServiceForwarder<ILogService>("Taxi");
            //services.AddTransient<INumberTripsRepository, NumberTripsRepository>();

            //services.AddTransient<TripsService>();
            services.AddTransient<IReceiveNationalService, ReceiveNationalService>();
            services.AddTransient<INumberReceptionRepository, NumberReceptionRepository>();
            services.AddTransient<IReceptionRepository, ReceptionRepository>();
            services.RegisterServiceForwarder<ILogService>("Hospital");
            services.AddTransient<INumberReceptionRepository, NumberReceptionRepository>();
            services.Configure<AccountDatabaseSettings>(
      Configuration.GetSection(nameof(AccountDatabaseSettings)));

            services.AddSingleton<IAccountDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<AccountDatabaseSettings>>().Value);
            services.AddHttpClient();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NationalService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NationalService v1"));
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
