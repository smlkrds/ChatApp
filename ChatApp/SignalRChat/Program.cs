using SignalRChat.Configurations;
using SignalRChat.Hubs;
using SignalRChat.Services.Interfaces;
using SignalRChat.Services;
using SignalRChat.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.WebHost.ConfigureServices(services => 
{
    services.AddSingleton<RedisConnectionFactory>();
    services.AddScoped<IRedisManager, RedisManager>();
    services.AddScoped<IRedisService, RedisService>();

    services.Configure<RedisConnectionConfig>(builder.Configuration.GetSection("RedisConnection:ChatAppRedisConnection"));
    services.Configure<ChatAppRedisConfig>(builder.Configuration.GetSection("ChatAppRedisConfig"));
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
