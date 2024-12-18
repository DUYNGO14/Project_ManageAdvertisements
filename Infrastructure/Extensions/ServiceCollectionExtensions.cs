﻿

using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrasture(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultSql");
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
        });
        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = false;
            options.SignIn.RequireConfirmedEmail = false;
        })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

        services.AddScoped<TimeSlotSeeder>();
        services.AddScoped<LocationSeeder>();
        services.AddScoped<DeviceSeeder>();
        services.AddScoped<UserSeeder>();
        services.AddScoped<DeviceTypeSeeder>();
        services.AddScoped<IInitialSeeder, InitialSeeder>();
    }
}
