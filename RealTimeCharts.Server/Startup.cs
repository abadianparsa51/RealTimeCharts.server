using RealTimeCharts.Server.HubConfig;

namespace RealTimeCharts.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IConfiguration configuration { get; }
        public void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy",builder => builder
                .WithOrigins("https://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            builder.Services.AddControllers();
            var app = builder.Build();

            services.AddSignalR();
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app , IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChartHub>("/chart");
            });
        }
    }
}
