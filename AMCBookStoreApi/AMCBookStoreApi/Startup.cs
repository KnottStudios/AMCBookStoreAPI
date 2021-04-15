using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Buffers;
using System.IO;
using System.Reflection;
using WebApi.Hal;

namespace AMCBookStoreApi
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
            services
                .AddMvcCore()
                .AddNewtonsoftJson(
                    options =>
                    {
                        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    })
                .AddApiExplorer()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddControllers();
            AddDependencyInjection(services);
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
        }

        private static void AddDependencyInjection(IServiceCollection services)
        {
            var config = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            /*
            services.AddSingleton<ITwitterLogger>(l => new FileLogger(config["File_Logger_Path"], config["File_Logger_File"]));
            services.AddTransient<IImageHandler, ImageHandler>();
            services.AddTransient<IEmojiHandler, EmojiHandler>();
            services.AddTransient<IUrlHandler, UrlHandler>();
            services.AddTransient<IUrlManager, UrlManager>();
            services.AddTransient<IEmojiManager, EmojiManager>();
            services.AddTransient<ITweetManager, TweetManager>();
            services.AddSingleton<ITwitterLocalStorage, TwitterLocalStorage>();
            services.AddSingleton<ITwitterDataHandler, TwitterDataHandler>();
            services.AddSingleton<ITwitterEngine>(s => new TwitterEngine(config["ConsumerKey"], config["ConsumerSecret"], config["AccessToken"], config["AccessSecret"]));
            */
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "BookStore V1");
            });

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
