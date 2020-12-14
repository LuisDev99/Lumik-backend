using Chat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Chat.Core.Entities.ShoppingBot;

namespace Chat.Core.Interfaces
{
    public interface IBotRepository
    {
        Task<IntentData> GetUserIntention(string userCommand);        
    }
}
