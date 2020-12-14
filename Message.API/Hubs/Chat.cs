using Chat.API.Models;
using Chat.Core.Entities;
using Chat.Core.Interfaces;
using Chat.Core.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async void SendCommand(UserRequestDTO request)
        {
            var response = await _chatService.HandleUserCommand(new UserCommand
            {
                Command = request.Command,
                Token = request.Token
            });
            
            //Broadcast the user his action response result
        }
    }
}
