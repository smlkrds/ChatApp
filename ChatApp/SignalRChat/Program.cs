using Microsoft.EntityFrameworkCore;
using SignalRChat.Configurations;
using SignalRChat.Contexts;
using SignalRChat.Factories;
using SignalRChat.Hubs;
using SignalRChat.Repositories;
using SignalRChat.Repositories.Interfaces;
using SignalRChat.Services;
using SignalRChat.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
});

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapHub<ChatHub>("/chatHub");

app.Run();
