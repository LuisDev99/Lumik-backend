using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            GroceryLists = new List<GroceryList>();
            ScheduledEvents = new List<Event>();
        }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public ICollection<GroceryList> GroceryLists;

        public ICollection<Event> ScheduledEvents;
    }
}
