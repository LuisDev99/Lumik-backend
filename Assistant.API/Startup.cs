using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Assistant.Infraestructure;
using Assistant.Core.Interfaces;
using Assistant.Infraestructure.Repositories;
using Assistant.Core.Services;
using Assistant.Core.Entities;

namespace Assistant.API
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
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);
            services.AddControllers();            
            services.AddDbContext<AssistantDbContext>((s, o) => o.UseSqlite("Data Source=data.db"));
            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

            // TODO: How to register multiple implementations of the same interface in Asp.Net Core?
            // Link: https://stackoverflow.com/questions/39174989/how-to-register-multiple-implementations-of-the-same-interface-in-asp-net-core

            // Smelly way of injecting dependencies (Possible solution in the link above)
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IGroceryItemService, GroceryItemService>();
            services.AddScoped<IGroceryListService, GroceryListService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IUserService, UserService>();

            // Ideal solution
            // services.AddScoped<IBaseService<>, BaseService<>>();
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
