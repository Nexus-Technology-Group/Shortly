using Hangfire;
using Hangfire.Redis.StackExchange;
using Shortly.Codes.Application;
using Shortly.Codes.DAL.Mongo.BackgroundJobs;

namespace Shortly.Host;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddAuthorization();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        #region MyRegion

        builder.Services.Configure<CodesOptions>(builder.Configuration.GetSection("Codes"));

        #endregion
        

        #region HangFire

        builder.Services.AddHangfire(configuration =>
            configuration.UseRedisStorage("redis_connection_string"));

        app.UseHangfireDashboard();
        
        RecurringJob.AddOrUpdate<CodeCleanerJob>(
            "clean-inactive-codes", 
            job => job.CleanInactiveCodes(), 
            Cron.Daily); 
        #endregion
        
        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.Run();
    }
}