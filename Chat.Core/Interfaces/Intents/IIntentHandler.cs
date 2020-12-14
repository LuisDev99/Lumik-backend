using Chat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Interfaces
{
    public interface IIntentHandler
    {
        Task<string> HandleUserIntent(UserIntent userIntent);
    }
}
