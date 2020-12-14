using Chat.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RakataController : ControllerBase
    {
        private readonly IChatService _chatService;

        public RakataController(IChatService chatService)
        {
            _chatService = chatService;
        }

        // GET: api/<RakataController>
        [HttpGet]
        public async Task<string> Get()
        {
            /**
             * Ignorar este controller y este GET 
             */

            var result = await _chatService.HandleUserCommand(new Core.Entities.UserCommand { 
                Command="Add zacarracatelas to lista23",
                Token="OK",
                UserID = "1",
            });

            return result;
        }        
    }
}
