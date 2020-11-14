using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.API.Models
{
    public class EventDTO : BaseEntityDTO
    {
        public string Title { get; set; }

        public DateTime TriggerDate { get; set; }        

        public int UserID { get; set; }
    }
}
