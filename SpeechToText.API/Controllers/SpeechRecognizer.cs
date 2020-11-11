using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpeechToText.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechRecognizer : ControllerBase
    {
        // GET: api/<SpeechRecognizer>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }        
    }
}
