using System.Text;
using BLL;
using Entities;
using EntityFrameworkTest.domain.context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Migrations;
using Repositories.Repository;
using SQLitePCL;
using WareHose.Common;

namespace WareHose;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder();
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        var jwtKey = builder.Configuration["Jwt:Key"];
        var jwtIssuer = builder.Configuration["Jwt:Issuer"];
        var jwtAudience = builder.Configuration["Jwt:Audience"];

        var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                ValidateIssuer = true,
                ValidIssuer = jwtIssuer,
                ValidateAudience = true,
                ValidAudience = jwtAudience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
        ;
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "WareHose API",
                Version = "v1",
                Description = "Документация для API проекта склада"
            });
        });

        builder.Services.AddDbContext<DbContext, AppDbContext>((optionsBuilder) =>
        {
            Batteries.Init();
            optionsBuilder
                .UseSqlite(connectionString);
        });
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
        AddRepositories(builder);
        AddBLL(builder);
        
        var app = builder.Build();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwagger();

        app.UseSwaggerUI();
        app.MapControllers();

        app.Run();
    }

    private static void AddRepositories(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IConcreteShoesRepository, ConcreteShoesRepository>();
        builder.Services.AddScoped<IShoesRepository, ShoesRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IIncomingInvoiceRepository, IncomingInvoiceRepository>();
        builder.Services.AddScoped<IOutgoingInvoiceRepository, OutgoingInvoiceInvoiceRepository>();
        builder.Services.AddScoped<IPlacementRepository, PlacementRepository>();
        builder.Services.AddScoped<ITransferRepository, TransferRepository>();
        builder.Services.AddScoped<IWareHouseRepository, WareHouseRepository>();
        builder.Services.AddScoped<IWriteOffRepository, WriteOffRepository>();
        builder.Services.AddSingleton<JwtService>();
    }
    private static void AddBLL(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<GetShoesPlacement>();
        builder.Services.AddScoped<LocalTransferShoes>();
        builder.Services.AddScoped<PlaceShoes>();
        builder.Services.AddScoped<ReceiveAndPlaceShoes>();
        builder.Services.AddScoped<SellAndTakeShoes>();
        builder.Services.AddScoped<TakeShoes>();
        builder.Services.AddScoped<TransferShoes>();
        builder.Services.AddScoped<WriteOffShoes>();
    }
}