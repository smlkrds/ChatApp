using SignalRChat.Hubs;
using SignalRChat.Mapping;
using SignalRChat.Contexts;
using SignalRChat.Services;
using SignalRChat.Factories;
using SignalRChat.Repositories;
using SignalRChat.Configurations;
using Microsoft.EntityFrameworkCore;
using SignalRChat.Services.Interfaces;
using SignalRChat.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.WebHost.ConfigureServices(services =>
{
    services.AddSingleton<RedisConnectionFactory>();
    services.AddScoped<IRedisManager, RedisManager>();
    services.AddScoped<IRedisService, RedisService>();
    services.AddScoped<IMessageService, MessageService>();

    services.AddTransient<IMessageRepository, MessageRepository>();

    services.Configure<RedisConnectionConfig>(builder.Configuration.GetSection("RedisConnection:ChatAppRedisConnection"));
    services.Configure<ChatAppRedisConfig>(builder.Configuration.GetSection("ChatAppRedisConfig"));

    services.AddDbContext<ChatAppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ChatAppDbConnection")));

    services.AddAutoMapper(typeof(MappingProfile));
});

builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapHub<ChatHub>("/chatHub");

app.Run();
