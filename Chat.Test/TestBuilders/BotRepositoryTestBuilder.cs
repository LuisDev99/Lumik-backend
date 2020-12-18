using Chat.BotInfrastucture;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Test.TestBuilders
{
    public class BotRepositoryTestBuilder
    {
        public BotRepository Build()
        {
            return new BotRepository(GetLuisServiceInstance());
        }

        public static LUISRuntimeClient GetLuisServiceInstance()
        {
            var key = "3c7727a5667944d89a0c3b14362fcffc";
            var predictionResourceName = "lumik";

            var predictionEndpoint = $"https://{predictionResourceName}.cognitiveservices.azure.com/";
            var credentials = new Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.ApiKeyServiceClientCredentials(key);

            return new LUISRuntimeClient(credentials) { Endpoint = predictionEndpoint };
        }
    }
}
