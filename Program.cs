using Microsoft.Extensions.Options;
using Telegram.Bot;
using WheatherTelegramBotApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfigurationSection botConfigurationSection= builder.Configuration.GetSection(BotConfiguration.ConfigurationName);
builder.Services.Configure<BotConfiguration>(botConfigurationSection);
BotConfiguration botConfiguration = builder.Configuration.Get<BotConfiguration>();

builder.Services.AddHttpClient("telegram_bot_client")
    .AddTypedClient<ITelegramBotClient>((httpClient,botClient)=>{
        TelegramBotClientOptions botClientOptions = new(botConfiguration.BotToken);
        return new TelegramBotClient(botClientOptions, httpClient);
    });

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
