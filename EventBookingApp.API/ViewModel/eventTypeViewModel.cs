using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.ViewModel
{
    public class eventTypeViewModel
    {
        public int Id { get; set;} 
        public string EventTypes { get; set; }
    }
}
