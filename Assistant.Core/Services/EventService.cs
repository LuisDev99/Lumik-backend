using Assistant.Core.Entities;
using Assistant.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Assistant.Core.Services
{
    public class EventService : BaseService<Event>, IEvent
    {
        private readonly IRepository<Event> _eventRepository;

        public EventService(IRepository<Event> eventRepository) : base(eventRepository)
        {
            _eventRepository = eventRepository;
        }

        //public ServiceResult<Event> Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public ServiceResult<IEnumerable<Event>> Filter(Expression<Func<Event, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public ServiceResult<IEnumerable<Event>> Get()
        //{
        //    throw new NotImplementedException();
        //}

        //public ServiceResult<Event> GetByID(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public ServiceResult<Event> Insert(int id, Event data)
        //{
        //    throw new NotImplementedException();
        //}

        //public ServiceResult<Event> Update(int id, Event data)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
