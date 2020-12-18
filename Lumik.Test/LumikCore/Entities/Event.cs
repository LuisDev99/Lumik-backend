using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Entities
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }

        public DateTime TriggerDate { get; set; }        

        public int UserID { get; set; }

        public User User { get; set; }
    }
}
