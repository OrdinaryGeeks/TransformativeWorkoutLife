using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography.X509Certificates;
using TransformationWorkoutLife.Models;
using TransformationWorkoutLogger.Data;
using TransformationWorkoutLogger.Models;
using Microsoft.Extensions.Azure;
using Azure.Storage.Queues;
using Azure.Storage.Blobs;
using Azure.Core.Extensions;
using System;

using Microsoft.AspNetCore.DataProtection;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

namespace TransformationWorkoutLogger
{
    public class Startup
    {
       public static ApplicationDbContext userContext = null;
        public static string SendGridAPIKey = "";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static void Initialize_DbContext_in_Startup(ServiceProvider serviceProvider)
        {
            IServiceScope serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
            userContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>(); 
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            SendGridAPIKey = Configuration["SendGridKey"];

            services.AddDbContext<DBContext>(options =>
           options.UseSqlServer(
               Configuration.GetConnectionString("DBContext")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
      
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();



            services.AddAzureClients(azureClientFactoryBuilder =>

            {

                azureClientFactoryBuilder.AddSecretClient(

               new System.Uri(Configuration["VaultUri"]));
                azureClientFactoryBuilder.AddBlobServiceClient(Configuration["BlobConnString:blob"], preferMsi: true);

            });

            services.AddSingleton<IKeyVaultManager, KeyVaultManager>();


            services.AddDatabaseDeveloperPageExceptionFilter();



        
           // services.AddDataProtection()
                //   .PersistKeysToAzureBlobStorage(Configuration.GetConnectionString("ConnString1"), "levsblobcontainer", "levricksblob")
             //.PersistKeysToAzureBlobStorage(blobSasUri = new System.Uri(Configuration["BlobContainerSASTokenUri"]))
            // .ProtectKeysWithAzureKeyVault(new System.Uri(Configuration["AXJEL"]), new EnvironmentCredential());

            //Removing this line below for an initial run will ensure the file is created correctly
            SecretClient client = new SecretClient(new System.Uri(Configuration["VaultUri"]), new EnvironmentCredential());

            services.AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = client.GetSecret("FacebookAppID").Value.Value;
                    facebookOptions.AppSecret = client.GetSecret("FacebookAppSecret").Value.Value;
                })
                .AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
     
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });


            //    Initialize_DbContext_in_Startup((ServiceProvider)app.ApplicationServices);
        }
    }
    internal static class StartupExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriOrConnectionString);
            }
        }
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddQueueServiceClient(serviceUri);
            }
            else
            {
                return builder.AddQueueServiceClient(serviceUriOrConnectionString);
            }
        }
    }
}
