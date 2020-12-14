using Chat.Core.Entities;
using Chat.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Bot.Configuration;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Chat.Core.Helpers;

namespace Chat.BotInfrastucture
{
    public class BotRepository : IBotRepository
    {
        private const string APP_ID = "b0eb6e36-3ba1-450c-9893-615eed20b25c";

        private readonly Guid _appGuid;
        private readonly LUISRuntimeClient _luisRuntime;

        public BotRepository(LUISRuntimeClient luisRuntime )
        {
            _appGuid = new Guid(APP_ID);
            _luisRuntime = luisRuntime;
        }

        public async Task<IntentData> GetUserIntention(string userCommand)
        {
            var request = new PredictionRequest { Query = userCommand };
            var response = await _luisRuntime.Prediction.GetSlotPredictionAsync(_appGuid, "Production", request);

            return new IntentData
            {
                Intent = BotHelper.ConvertStringToIntent(response.Prediction.TopIntent),
                Entities = response.Prediction.Entities
            };
        }
    }
}
