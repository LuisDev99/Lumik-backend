using Chat.Core.Entities;
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
        [HttpPost]
        public async Task<string> PostUserCommand([FromBody] UserCommand userCommand)
        {
            var result = await _chatService.HandleUserCommand(userCommand);

            return result;
        }        
    }
}
