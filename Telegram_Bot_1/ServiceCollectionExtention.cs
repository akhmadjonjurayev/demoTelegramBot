using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Telegram_Bot_1
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services,IConfiguration configuration)
        {
            
            var client = new TelegramBotClient(configuration["Token"]);
            var webHook = $"{configuration["Url"]}/api/bot/post";
            client.SetWebhookAsync( url: webHook,allowedUpdates : Array.Empty<UpdateType>()).Wait();
           
            return services.AddSingleton<ITelegramBotClient>(client);
        }
    }
}
