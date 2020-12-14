using Chat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Interfaces.Intents
{
    public abstract class BaseIntent
    {
        protected readonly IAssistantRepository _assistantRepository;

        protected BaseIntent(IAssistantRepository assistantRepository)
        {
            _assistantRepository = assistantRepository;
        }

        public abstract Task<string> Act(UserIntent userIntention);
    }
}
