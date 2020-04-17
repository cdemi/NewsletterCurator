using System;
using System.Net.Http;
using System.Text;
using Google.Apis.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsletterCurator.Data;
using NewsletterCurator.HTMLScraper;
using NewsletterCurator.YouTubeScraper;
using Polly;

namespace NewsletterCurator.Web
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
            services.AddApplicationInsightsTelemetry();
            services.AddHttpsRedirection(options => { options.HttpsPort = 443; });
            services.AddControllersWithViews();

            services.AddDbContext<NewsletterCuratorContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NewsletterCuratorContext"), builder => builder.MigrationsAssembly("NewsletterCurator.Data.SqlServer")));
            services.AddTransient(s => new EmailService.EmailService(new System.Net.Mail.SmtpClient(Configuration.GetValue<string>("SMTP:Host"), Configuration.GetValue<int>("SMTP:Port"))
            {
                Credentials = new System.Net.NetworkCredential(Configuration.GetValue<string>("SMTP:Username"), Configuration.GetValue<string>("SMTP:Password")),
                EnableSsl = Configuration.GetValue<bool>("SMTP:EnableSsl")
            }, Configuration.GetValue<string>("Mail:List-Unsubscribe-Mail")));
            services.AddTransient(s=> new BaseClientService.Initializer() {
                ApiKey = Configuration.GetValue<string>("YouTubeKey"),
                ApplicationName = this.GetType().ToString()
            });
            services.AddTransient<YouTubeMetadataService>();
            services.AddHttpClient("github", c =>
            {
                c.BaseAddress = new Uri("https://api.github.com/");
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                c.DefaultRequestHeaders.Add("User-Agent", "NewsletterCurator-Archive");
                c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Configuration.GetValue<string>("GitHub:Username")}:{Configuration.GetValue<string>("GitHub:PersonalAccessToken")}")));
            });

            services.AddHealthChecks();

            services.AddHttpClient("httpClient", client =>
            {
                client.DefaultRequestHeaders.Add("User-Agent", Configuration.GetValue<string>("HttpClient:UserAgent"));
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
                client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.None
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));

            services.AddTransient<HTMLScraperService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }


            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<NewsletterCuratorContext>())
                {
                    context.Database.Migrate();
                }
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Security-Policy", Configuration.GetValue<string>("Content-Security-Policy"));
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "newsletter",
                    pattern: "Newsletter/{action=Index}/{id?}", defaults: new { controller = "Newsletter" });

                endpoints.MapHealthChecks("/health");

                if (env.IsDevelopment())
                {
                    endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                }
                else
                {
                    endpoints.MapControllerRoute(
                       name: "default",
                       pattern: Configuration.GetValue<string>("AdminKey") + "/{controller=Home}/{action=Index}/{id?}");
                }
            });

        }
    }
}
