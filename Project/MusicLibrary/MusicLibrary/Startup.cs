using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using MusicLibrary.api.Data.Repositories;
using MusicLibrary.api.Middleware;
using MusicLibrary.Api.Services;
using MusicLibrary.Application.Services;
using MusicLibrary.Data;

namespace MusicLibrary
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

            services.AddDbContext<ApiDbContext>(options =>
            options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Music Library API Project", Version = "v1.1" });
            });

            services.AddTransient<INotificationService, NotificationService>();

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat(
                    "xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat(
                    "json", MediaTypeHeaderValue.Parse("application/json"));
            })
                .AddXmlSerializerFormatters();

            IConfigurationSection jwtSection = this.Configuration.GetSection("Jwt");
            services.Configure<JwtSettings>(jwtSection);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(ops => ops.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSection["Key"]))
                });

            //repositories
            services.AddScoped<AlbumsRepository>();
            services.AddScoped<ArtistsRepository>();

            //services
            services.AddScoped<IRequestLogger, RequestLogger>();
            services.AddScoped<IUserService, UserService>();
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
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music Library V1");
            });


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptionHandler(new ExceptionHandlerOptions()
            {
                ExceptionHandler = new ExceptionHandlingMiddleware().Invoke
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });





        }
    }
}
