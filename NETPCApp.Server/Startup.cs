using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NETPCApp.Application.Interfaces;
using NETPCApp.Application.Mapper;
using NETPCApp.Domain.IRepositories;
using NETPCApp.Domain.Models;
using NETPCApp.Infrastructure.Persistence;
using NETPCApp.Infrastructure.Repositories;
using NETPCApp.Infrastructure.Services;
using System.Text;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Database context configuration
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Identity setup for user management
        services.AddIdentity<User, IdentityRole<int>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // JWT Authentication configuration
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });

        services.AddAutoMapper(typeof(MappingProfile));

        // Adding custom services and repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IContactService, ContactService>();

        // Enable CORS (Cross-Origin Resource Sharing) for frontend communication
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp", builder =>
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod());
        });

        // Add controllers and JSON serialization settings
        services.AddControllers()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        // Add Swagger for API documentation
        services.AddSwaggerGen();

        // Add options for configuration if needed
        services.AddOptions();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // Swagger is accessible from /api-docs
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API V1");
                c.RoutePrefix = "swagger";
            });
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        // Enable HTTPS redirection
        app.UseHttpsRedirection();

        // Use routing
        app.UseRouting();

        // Enable CORS
        app.UseCors("AllowAngularApp");

        // Enable Authentication and Authorization
        app.UseAuthentication();
        app.UseAuthorization();

        // Apply migrations
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }

        // Map endpoints to controllers
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
