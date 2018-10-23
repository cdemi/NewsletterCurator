using System;
using System.Net.Http;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.SnapshotCollector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NewsletterCurator.Data;
using NewsletterCurator.HTMLScraper;
using Polly;

namespace NewsletterCurator.Web
{
    public class Startup
    {
        private class SnapshotCollectorTelemetryProcessorFactory : ITelemetryProcessorFactory
        {
            private readonly IServiceProvider _serviceProvider;

            public SnapshotCollectorTelemetryProcessorFactory(IServiceProvider serviceProvider) =>
                _serviceProvider = serviceProvider;

            public ITelemetryProcessor Create(ITelemetryProcessor next)
            {
                var snapshotConfigurationOptions = _serviceProvider.GetService<IOptions<SnapshotCollectorConfiguration>>();
                return new SnapshotCollectorTelemetryProcessor(next, configuration: snapshotConfigurationOptions.Value);
            }
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpsRedirection(options => { options.HttpsPort = 443; });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<NewsletterCuratorContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NewsletterCuratorContext"), builder => builder.MigrationsAssembly("NewsletterCurator.Data.SqlServer")));
            services.AddTransient(s => new EmailService.EmailService(new System.Net.Mail.SmtpClient(Configuration.GetValue<string>("SMTP:Host"), Configuration.GetValue<int>("SMTP:Port"))
            {
                Credentials = new System.Net.NetworkCredential(Configuration.GetValue<string>("SMTP:Username"), Configuration.GetValue<string>("SMTP:Password")),
                EnableSsl = Configuration.GetValue<bool>("SMTP:EnableSsl")
            }, Configuration.GetValue<string>("Mail:List-Unsubscribe-Mail")));
            services.AddTransient<HTMLScraperService>();
            services.AddHttpClient<HTMLScraperService>((client) =>
            {
                client.DefaultRequestHeaders.Add("User-Agent", Configuration.GetValue<string>("HttpClient:UserAgent"));
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
                client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.None
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));

            // Configure SnapshotCollector from application settings
            services.Configure<SnapshotCollectorConfiguration>(Configuration.GetSection(nameof(SnapshotCollectorConfiguration)));

            // Add SnapshotCollector telemetry processor.
            services.AddSingleton<ITelemetryProcessorFactory>(sp => new SnapshotCollectorTelemetryProcessorFactory(sp));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<NewsletterCuratorContext>())
                {
                    context.Database.Migrate();
                }
            }


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "newsletter",
                    template: "Newsletter/{action=Index}/{id?}", defaults: new { controller = "Newsletter" });

                if (env.IsDevelopment())
                {
                    routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                }
                else
                {
                    routes.MapRoute(
                       name: "default",
                       template: Configuration.GetValue<string>("AdminKey") + "/{controller=Home}/{action=Index}/{id?}");
                }
            });
            
        }
    }
}
