using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Generator;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.IO;

using nsCategory;
using nsProduct;

public partial class Handler {

    public IConfigurationRoot Configuration { get; }

    public Handler(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

        if (env.IsDevelopment())
        {
            // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
            // builder.AddUserSecrets();
        }

        Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {

        // in-memory
        services.AddDbContext<DB>(options => options.UseInMemoryDatabase());
        services.AddSingleton<ICategory, CategoryAPI>();
        services.AddSingleton<nsRepoProduct.IProduct, nsRepoProduct.ProductAPI>();
        services.AddSingleton<StoreRepo.IStore, StoreRepo.StoreAPI>();

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials() );
        });
        services.AddMvc();

        // Inject an implementation of ISwaggerProvider with defaulted settings applied
        services.AddSwaggerGen();

        services.ConfigureSwaggerGen(options =>
        {
            options.SingleApiVersion(new Info
            {
                Version = "v1",
                Title = "AmaClone API",
                Description = "AmaClone API"
            });
            options.IgnoreObsoleteActions();
            options.IgnoreObsoleteProperties();
            options.DescribeAllEnumsAsStrings();
        });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger, DB db) {
        logger.AddDebug();

        // app.UseSession();
        app.UseCors("CorsPolicy");

        // if (env.IsDevelopment())
        // {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseStatusCodePages();
        // }

        Seed.Initialize(db, env.IsDevelopment());
        db.Database.EnsureCreated();

        app.UseStaticFiles();

        app.UseMvc();

        // Enable middleware to serve generated Swagger as a JSON endpoint
        app.UseSwagger();

        // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
        app.UseSwaggerUi();
    }

}


public partial class DB : DbContext {
    public DB(DbContextOptions<DB> options): base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}