using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OfferEngine.Data;
using Newtonsoft.Json.Serialization;

namespace OfferEngine
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
            services.AddDbContext<PromotionEngineContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("PromotionalEngine")));

            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<IProductRepo,ProductRepo>();
            services.AddScoped<IProductWriteRepo,ProductWriteRepo>();
            services.AddScoped<ICartDetailsReadRepo, CartDetailsReadRepo>();
            services.AddScoped<ICartDetailsWriteRepo, CartDetailsWriteRepo>();
            services.AddScoped<IPromotionalOfferDetailsReadRepo,  PromotionalOfferDetailsReadRepo>();
            services.AddScoped<IPromotionalOfferDetailsWriteRepo, PromotionalOfferDetailsWriteRepo>();
            services.AddScoped<IPromotionalCategoryReadRepo, PromotionalCategoryReadRepo>();
            services.AddScoped<IPromotionalCategoryWriteRepo, PromotionalCategoryWriteRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
