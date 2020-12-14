using Chat.Core.Entities;
using Chat.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Services
{
    public class ChatService : IChatService
    {
        private readonly IBotRepository _botRepository;
        private readonly IIntentHandler _intentHandler;

        public ChatService(IBotRepository botRepository, IIntentHandler intentHandler)
        {
            _botRepository = botRepository;
            _intentHandler = intentHandler;
        }

        public async Task<string> HandleUserCommand(UserCommand userRequest)
        {
            // Figure out the user intention
            var userIntentionResult = await _botRepository.GetUserIntention(userRequest.Command);

            // Act base on intention (by calling the corresponding API endpoint base on intent)
            var messageResult = await _intentHandler.HandleUserIntent(new UserIntent { 
                UserID = Convert.ToInt32(userRequest.UserID),
                IntentData = userIntentionResult,
            });

            // Return
            return messageResult;

        }
    }
}
