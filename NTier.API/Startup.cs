using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MVCNTier.BLL.Services.AppUserService;
using MVCNTier.BLL.Services.GenreService;
using MVCNTier.BLL.Services.PostService;
using MVCNTier.Core.Entities;
using MVCNTier.Core.IRepositories;
using MVCNTier.DAL;
using MVCNTier.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCNTier.BLL.Automapper;

namespace NTier.API
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


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NTier.API", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //repos
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ILikeRepository, LikeRepository>();
            services.AddTransient<IPostRepository, PostRepository>();

            //services

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPostService, PostService>();

            //AutoMapper
            services.AddAutoMapper(typeof(Mapping));

            services.AddCors(options => options.AddPolicy("MyCors", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NTier.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(options => options.AllowAnyOrigin());

            app.UseCors("MyCors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
