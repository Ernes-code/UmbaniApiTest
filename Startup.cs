using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using UmbaniApiTest.Entities;
using UmbaniApiTest.Implementation;
using UmbaniApiTest.Services;

namespace UmbaniApiTest
{
    public class Startup
    {
        public Startup(IHostingEnvironment env) 
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build(); 
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.Configure<CookiePolicyOptions>(options =>
              {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                  options.MinimumSameSitePolicy = SameSiteMode.None;
              });

            _ = services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                .AddAzureAD(options => this.Configuration.Bind("AzureAd", options));

            _ = services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
              {
                  options.Authority = options.Authority + "/v2.0/";

                  options.TokenValidationParameters.ValidateIssuer = false;
              });

            _ = services.AddAuthorization(options => options.AddPolicy("DivisionManager", policyBuilder => policyBuilder.RequireClaim("groups", "034fc3da-3a24-48e1-ab75-fd76466a5c7d")));

            _ = services.AddMvc(options =>
              {
                  var policy = new AuthorizationPolicyBuilder()
                      .RequireAuthenticatedUser()
                      .Build();
                  options.Filters.Add(new AuthorizeFilter(policy));
                  options.EnableEndpointRouting = false;
              })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            string connectionString = Configuration["Data:ConnectionStrings:DefaultConnection"];
            _ = services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            _ = services.AddScoped<IGetMeasurementData, GetMeasurementData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }
            else
            {
                _ = app.UseExceptionHandler("/Home/Error");
                _ = app.UseHsts();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();
            _ = app.UseCookiePolicy();

            _ = app.UseAuthentication();

            _ = app.UseMvc(routes =>
              {
                  _ = routes.MapRoute(
                      name: "default",
                      template: "{controller=Home}/{action=Index}/{id?}");
              });
        }
    }
}
