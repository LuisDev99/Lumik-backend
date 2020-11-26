﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.API.Models;
using Assistant.API.Models.InsertModels;
using Assistant.Core.Entities;
using Assistant.Core.Enums;
using Assistant.Core.Interfaces;
using Assistant.Core.Services;
using Assistant.Infraestructure;
using Microsoft.AspNetCore.Mvc;


namespace Assistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/<EventsController>
        [HttpGet]
        public ActionResult<IEnumerable<EventDTO>> Get()
        {
            var service = _eventService.Get();

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }
            
            return Ok(service.Result.Select(
                _event => new EventDTO
                {
                    ID = _event.ID,
                    Title = _event.Title,
                    TriggerDate = _event.TriggerDate,
                    UserID = _event.UserID
                }    
            ));
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult<EventDTO> Get(int id)
        {
            var service = _eventService.GetByID(id);

            if(service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok(new EventDTO
            {
                ID = service.Result.ID,
                Title = service.Result.Title,
                TriggerDate = service.Result.TriggerDate,
                UserID = service.Result.UserID
            });            
        }

        // POST api/<EventsController>
        [HttpPost]
        public ActionResult<EventDTO> Post([FromBody] AddEvent value)
        {
            var service = _eventService.Insert(new Event
            {
                Title = value.Title,
                UserID = value.UserID,
                TriggerDate = value.TriggerDate,                 
            });

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok(new EventDTO
            {
                ID = service.Result.ID,
                Title = service.Result.Title,
                TriggerDate = service.Result.TriggerDate,
                UserID = service.Result.UserID,
            });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public ActionResult<EventDTO> Put(int id, [FromBody] AddEvent value)
        {
            var service = _eventService.Update(new Event
            {
                ID = id,
                Title = value.Title,
                UserID = value.UserID,
                TriggerDate = value.TriggerDate,
            });

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok(new EventDTO
            {
                ID = id,
                Title = value.Title,
                UserID = value.UserID,
                TriggerDate = value.TriggerDate,
            });
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public ActionResult<EventDTO> Delete(int id)
        {
            var service = _eventService.Delete(new Event { ID = id });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok(new EventDTO {
                ID = service.Result.ID,
                Title = service.Result.Title,
                UserID = service.Result.UserID,
                TriggerDate = service.Result.TriggerDate
            });

        }
    }
}
