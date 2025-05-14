using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using YardBooking.DAL.Data;
using YardBooking.BLL.AutoMapper;
using YardBooking.DAL.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using YardBooking.DAL.Data.Models;
using YardBooking.Application.Services;
using YardBooking.BLL.IServices;
using YardBooking.DAL.Inerfaces;
using YardBooking.BLL.Services;
namespace YardBooking.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register repositories
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

            // Register services
            builder.Services.AddScoped<IBookingService, BookingService>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Register repository
            builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();

            // Register service
            builder.Services.AddScoped<IScheduleService, ScheduleService>();

            builder.Services.AddScoped<IUserRepo,UserRepo>();


            // add automapper
            builder.Services.AddAutoMapper(m => m.AddProfile(new MappingProfile()));

            builder.Services.AddDbContext<YardBookingContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register services
            builder.Services.AddScoped<IAuthService, AuthService>();


            // Add Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<YardBookingContext>()
            .AddDefaultTokenProviders();

            // Add JWT Authentication
            var jwtSettings = builder.Configuration.GetSection("Jwt:Key").Value;
            var key = Encoding.ASCII.GetBytes(jwtSettings);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "jwt";
                options.DefaultChallengeScheme = "jwt";
            })
            .AddJwtBearer("jwt",options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,                };
            });


            var app = builder.Build();

            // add roles
            async Task SeedRolesAsync(IServiceProvider serviceProvider)
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string[] roleNames = { "player", "owner" };

                foreach (var roleName in roleNames)
                {
                    var roleExists = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await SeedRolesAsync(services);
            }


            app.Run();
        }
    }
}
