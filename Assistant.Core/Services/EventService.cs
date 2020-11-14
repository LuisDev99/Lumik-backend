using Assistant.Core.Entities;
using Assistant.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Assistant.Core.Services
{
    public class EventService : BaseService<Event>, IEventService
    {
        public EventService(IRepository<Event> eventRepository) : base(eventRepository)
        {
        }

    }
}
