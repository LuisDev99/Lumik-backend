using Chat.Core.Entities;
using Chat.Core.Entities.APIModels;
using Chat.Core.Interfaces;
using Chat.Core.Interfaces.Intents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Intents
{
    public class EventIntent : BaseIntent
    {
        public EventIntent(IAssistantRepository assistantRepository)
            : base(assistantRepository)
        {
        }

        public override async Task<string> Act(UserIntent userIntention)
        {
            var intentionData = userIntention.IntentData;

            if(intentionData.Intent == ShoppingBot.Intent.CreateEvent)
            {
                return await _assistantRepository.CreateEvent(new Event {
                    Title = intentionData.Entities[JsonEntitiesNameConstants.ACTIVITY_NAME].ToString(),
                    UserID = userIntention.UserID,
                    TriggerDate = Convert.ToDateTime(intentionData.Entities[JsonEntitiesNameConstants.DATETIME].ToString())
                });
            }

            return "I could not figure out what you said!";
        }
    }
}
