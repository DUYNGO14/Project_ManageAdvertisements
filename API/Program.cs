using API.Extensions;
using API.Middlewares;
using Infrastructure.Seeders;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    builder.AddPresentation();
    // Add CORS policy to allow requests from localhost:7220
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost", policy =>
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()  
            .AllowAnyMethod());
    });
    var app = builder.Build();
    // Enable CORS globally (apply to all controllers)
    app.UseCors("AllowLocalhost");
    //seed
    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IInitialSeeder>();
    await seeder.Seed();

    //middleware handler exception
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestTimeLoggingMiddleware>();
    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseStaticFiles();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup failed");
}
finally
{
    Log.CloseAndFlush();
}
