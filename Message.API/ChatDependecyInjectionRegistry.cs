using Chat.Core.Interfaces;
using Chat.Core.Services;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.BotInfrastucture;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
using Chat.Core.Handler;
using Chat.API.Middlewares;

namespace Chat.API
{
    public static class ChatDependecyInjectionRegistry
    {
        public static IServiceCollection AddChatServices(this IServiceCollection services)
        {
            services.AddSingleton(GetLuisServiceInstance());

            services.AddScoped<AuthMiddleware>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IIntentHandler, IntentHandler>();            
            services.AddScoped<IBotRepository, BotRepository>();
            services.AddScoped<IAssistantRepository, AssistantRepository>();

            return services;
        }

        public static LUISRuntimeClient GetLuisServiceInstance()
        {
            var key = "3c7727a5667944d89a0c3b14362fcffc";
            var predictionResourceName = "lumik";

            var predictionEndpoint = $"https://{predictionResourceName}.cognitiveservices.azure.com/";
            var credentials = new Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.ApiKeyServiceClientCredentials(key);

            return new LUISRuntimeClient(credentials) { Endpoint = predictionEndpoint };            
        }


        public async static void LuisRuntimeTestExample()
        {
            var appId = "b0eb6e36-3ba1-450c-9893-615eed20b25c";
            var key = "3c7727a5667944d89a0c3b14362fcffc";
            var predictionResourceName = "lumik";

            var predictionEndpoint = $"https://{predictionResourceName}.cognitiveservices.azure.com/";
            var credentials = new Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.ApiKeyServiceClientCredentials(key);
            var runtimeClient = new LUISRuntimeClient(credentials) { Endpoint = predictionEndpoint };

            var gAppId = new Guid(appId);

            var request = new PredictionRequest { Query = "add tomatoes to rakata1" };
            var predi = await runtimeClient.Prediction.GetSlotPredictionAsync(gAppId, "Production", request);            
        }
    }
}
