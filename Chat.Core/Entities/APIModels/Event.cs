using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Entities.APIModels
{
    public class Event
    {
        public string Title { get; set; }

        public DateTime TriggerDate { get; set; }        

        public int UserID { get; set; }
    }
}
